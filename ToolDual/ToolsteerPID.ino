
float localActuatorLimit = toolSettings.maxActuatorLimit; // we'll change this to move our actuator based on distance from XTE

//float kP = toolSettings.Kp / 10;							// steering gain (deg per cm - start at 0.25)
//float maxSteer = toolSettings.maxActuatorLimit;     // absolute steering limit (eg 5)
//float lowXteZone = toolSettings.Ki / 10;					// cm where we soften response (eg 5)
//float minAuthority = toolSettings.highPWM / 10;			// deg allowed near center

float computeSteer(float xte_cm)
{
	// proportional steering
	float steer = toolSettings.Kp * xte_cm;

	// soft authority reduction near center
	float ax = abs(xte_cm);

	if (ax < toolSettings.Ki)
	{
		float scale = ax / toolSettings.Ki;   // 0 to 1
		float allowed = toolSettings.highPWM + scale * (toolSettings.maxActuatorLimit - toolSettings.highPWM);

		steer = constrain(steer, -allowed, allowed);
	}
	else
	{
		steer = constrain(steer, -toolSettings.maxActuatorLimit, toolSettings.maxActuatorLimit);
	}

	return steer;
}

int updateBangBangSteering(float desired, float actual)
{
	static int lastDrive = 0;

	const float engage = 0.7;
	const float release = 0.3;

	float error = desired - actual;

	if (lastDrive == 0)
	{
		if (error > engage) lastDrive = 255;
		else if (error < -engage) lastDrive = -255;
	}
	else
	{
		if (abs(error) < release)
			lastDrive = 0;
	}

	return lastDrive;
}

void calcSteeringPID(void)
{

	// Things we can corrupt and abuse from the form - basically all of them as BB doesn't care about gain etc
	// Proportional gain - "XTE to full steer ahead"
	// Integral gain - "XTE to steer to half the limit"
	// MaxPWM - 

	if (toolSettings.isBangBang)
	{

		float desired = computeSteer(toolXTE_cm);
		pwmDrive = updateBangBangSteering(desired, actuatorPosition);

	}
	else
	{
		pValue = toolSettings.Kp * toolXTE_cm * 0.2;
		pwmDrive = (int16_t)pValue;

		errorAbs = abs(toolXTE_cm);
		int16_t newMax = 0;

		if (errorAbs < toolSettings.lowHighDistance)
		{
			newMax = (errorAbs * lowHighPerCM) + toolSettings.lowPWM;
		}
		else
			newMax = toolSettings.highPWM;

		// add min throttle factor so no delay from motor resistance.
		if (pwmDrive < 0)
			pwmDrive -= toolSettings.minPWM;
		else if (pwmDrive > 0)
			pwmDrive += toolSettings.minPWM;

		// limit the pwm drive
		if (pwmDrive > newMax)
			pwmDrive = newMax;
		if (pwmDrive < -newMax)
			pwmDrive = -newMax;

	}
	if (toolSettings.invertActuator)
		pwmDrive *= -1;
}

// #########################################################################################

void motorDrive(void)
{
	// Used with Cytron MD30C Driver
	// Steering Motor
	// Dir + PWM Signal

	// Override the set pwmDrive with manualPWM if not zero
	if (manualPWM != 0)
	{
		pwmDrive = manualPWM;
	}

	if (abs(actuatorPositionPercent) > toolSettings.maxActuatorLimit) // stop moving if we're at max already
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

	if (toolSettings.invertActuator)
		pwmDrive *= -1;

	pwmDisplay = pwmDrive;

	if (toolSettings.CytronDriver)
	{
		// Cytron MD30C Driver Dir + PWM Signal
		if (pwmDrive >= 0)
		{
			bitSet(PORTD, 4); // set the correct direction
		}
		else
		{
			bitClear(PORTD, 4);
			pwmDrive = -1 * pwmDrive;
		}

		// write out the 0 to 255 value
		analogWrite(PWM1_LPWM, pwmDrive);
	}
}
