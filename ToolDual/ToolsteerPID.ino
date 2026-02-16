void calcSteeringPID(void)
{

    // what do we know here - we know the actuator/WAS position from the sensor
    // and we know how far off the line we are (toolXTE_cm)
    // so, given we're on a slow-steering valve, we want to limit the amount of turning we do
    // and start backing it off (aka straightening up) as we approach the line
    // 
    // 
    //Proportional only
    pValue = toolSettings.Kp * toolXTE_cm * 0.2;
    pwmDrive = (int16_t)pValue;

    errorAbs = abs(toolXTE_cm);
    int16_t newMax = 0;

    if (errorAbs < toolSettings.lowHighDistance)
    {
        newMax = (errorAbs * lowHighPerCM) + toolSettings.lowPWM;
    }
    else newMax = toolSettings.highPWM;

    //add min throttle factor so no delay from motor resistance.
    if (pwmDrive < 0) pwmDrive -= toolSettings.minPWM;
    else if (pwmDrive > 0) pwmDrive += toolSettings.minPWM;

    //limit the pwm drive
    if (pwmDrive > newMax) pwmDrive = newMax;
    if (pwmDrive < -newMax) pwmDrive = -newMax;

    if (toolSettings.invertActuator) pwmDrive *= -1;

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

    if (toolSettings.invertActuator) pwmDrive *= -1;
 
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
}
