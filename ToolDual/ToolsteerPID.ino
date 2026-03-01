float historicalXTE[30];
uint8_t hxte = 0;
int8_t approachSide = 0;
unsigned long lastApproachEvalMs = 0;

int8_t inferApproachSideFromHistory(uint8_t window)
{
    if (window < 4) window = 4;
    if (window > 30) window = 30;

    uint8_t half = window / 2;
    float oldMean = 0;
    float newMean = 0;

    for (uint8_t i = 0; i < window; i++)
    {
        uint8_t idx = (hxte + 30 - window + i) % 30;
        float value = historicalXTE[idx];

        if (i < half) oldMean += value;
        else newMean += value;
    }

    oldMean /= half;
    newMean /= (window - half);

    float oldAbs = fabs(oldMean);
    float newAbs = fabs(newMean);
    float deadband = 0.5;

    if ((newAbs + deadband) < oldAbs)
    {
        if (oldMean < -deadband) return -1;
        if (oldMean > deadband) return 1;
    }

    if (oldMean < -deadband && newMean > deadband) return -1;
    if (oldMean > deadband && newMean < -deadband) return 1;
    return 0;
}

void calcSteeringPID(void)
{
    historicalXTE[hxte++] = toolXTE_cm;
    if (hxte == 30) hxte = 0;

    if ((millis() - lastApproachEvalMs) >= 1000UL)
    {
        approachSide = inferApproachSideFromHistory(10);

        if (approachSide < 0) sendHardwareMessageStream("Approaching from left");
        else if (approachSide > 0) sendHardwareMessageStream("Approaching from right");
        else sendHardwareMessageStream("Approach unclear");

        lastApproachEvalMs = millis();
    }
    
    //proportional type valve
    if (toolSettings.isDirectionalValve == 0)
    {
        pValue = toolSettings.Kp * toolXTE_cm * 0.2;
        pwmDrive = (int16_t)pValue;

        errorAbs = abs(toolXTE_cm);

        float f_Ki = (float)(toolSettings.Ki) * 0.1;

        int16_t newMax = 0;

        if (errorAbs < toolSettings.lowHighDistance)
        {
            newMax = (errorAbs * lowHighPerCM) + toolSettings.lowPWM;
        }
        else newMax = toolSettings.highPWM;

        //if within 1/2 the lowHighDistance begin integral
        if (errorAbs < (toolSettings.lowHighDistance)) iValue += (f_Ki * toolXTE_cm * 0.01);
        else iValue = 0;

        //check if 0 crossing
        if ((lastXTE_Error >= 0 && toolXTE_cm <= 0) || (lastXTE_Error <= 0 && toolXTE_cm >= 0))
        {
            iValue = 0;   
        }
        
        lastXTE_Error = toolXTE_cm;

        //limit integral
        if (iValue > 30) iValue = 30;
        if (iValue < -30) iValue = -30;

        //add the integral value;
        pwmDrive += iValue;  
        
        //add min throttle factor so no delay from motor resistance.
        if (pwmDrive < 0) pwmDrive -= toolSettings.minPWM;
        else if (pwmDrive > 0) pwmDrive += toolSettings.minPWM;

        //limit the pwm drive
        if (pwmDrive > newMax) pwmDrive = newMax;
        if (pwmDrive < -newMax) pwmDrive = -newMax;
    }
    else //Directional valve
    {
        pwmDrive = 0;
        if (guidanceStatus != 0)
        {
            errorAbs = abs(toolXTE_cm);

            if (errorAbs > toolSettings.lowHighDistance)
            {
                if (toolXTE_cm > 0) pwmDrive = 255;
                else pwmDrive = -255;
            }
            else
            {
                if (valveOnCounter < toolSettings.valveOnTime) 
                {
                    pwmDrive = 255;
                }
                else if (valveOffCounter < toolSettings.valveOffTime) 
                {
                    pwmDrive = 0;
                }
                else if (valveOffCounter > toolSettings.valveOffTime)
                {
                    valveOnCounter = 0;
                    valveOffCounter = 0;
                }

                if (toolXTE_cm < 0) pwmDrive *= -1;

                if (abs(toolXTE_cm) < 4 && approachSide != 0)
                {
                    sendHardwareMessageStream("Within 4cm, using approach side for directional valve"); 
                    pwmDrive = (int16_t)(-approachSide * 255);
                }

            }
        }
    }
}

//#########################################################################################

void motorDrive(void)
{
    // Used with Cytron MD30C Driver
    // Steering Motor
    // Dir + PWM Signal

	//Override the set pwmDrive with manualPWM if not zero
    if (manualPWM != 0)
    {
        pwmDrive = manualPWM;
    }

    if (toolSettings.invertActuator) pwmDrive *= -1;

    if (abs(actuatorPositionPercent) > toolSettings.maxActuatorLimit) 
    {
      if (actuatorPositionPercent > 0 && pwmDrive > 0)
      {
          pwmDrive = 0;
      }
      else if (actuatorPositionPercent < 0 && pwmDrive < 0)
      {
          pwmDrive = 0;
      }
    }

 
    pwmDisplay = pwmDrive;

    if (toolSettings.CytronDriver)
    {
        // Cytron MD30C Driver Dir + PWM Signal
        if (pwmDrive >= 0)
        {
            bitSet(PORTD, 4);  //set the correct direction
        }
        else
        {
            bitClear(PORTD, 4);
            pwmDrive = -1 * pwmDrive;
        }

        //write out the 0 to 255 value
        analogWrite(PWM1_LPWM, pwmDrive);
    }
    else
    {
        // IBT 2 Driver Dir1 connected to BOTH enables
        // PWM Left + PWM Right Signal

        if (pwmDrive > 0)
        {
            analogWrite(PWM2_RPWM, 0);//Turn off before other one on
            analogWrite(PWM1_LPWM, pwmDrive);
        }
        else
        {
            pwmDrive = -1 * pwmDrive;
            analogWrite(PWM1_LPWM, 0);//Turn off before other one on
            analogWrite(PWM2_RPWM, pwmDrive);
        }

        pwmDisplay = pwmDrive;
    }
}
