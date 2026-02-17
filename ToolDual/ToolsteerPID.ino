
#define steerLeft -255
#define steerRight 255
#define steerStop 0
elapsedMillis steerStarted = 0;
elapsedMillis steerPaused = 0;

float steerGapTime	= toolSettings.kp * 10; // kp/pgain * ms between steering changes
float steerMaxTime	= toolSettings.ki * 10; // ki/integral * ms maximum time to hold a steer
float deadZone		= toolSettings.maxPWM / 10; // cm of XTE where we do not steer

void calcSteeringPID(void)
{

	if (toolSettings.isBangBang)
	{
		static bool isPausing = false;
		// do we want to scale the steerMaxTime if way off the line, and lower it when close?
		// Maybe steerMaxTime = (toolSettings.ki * 10) * (abs(toolXTE_cm) / 100);
		// so at 100cm off, max time is full, but at 50cm off, max time is half, etc.
		// This would make it more responsive when far off the line, and less twitchy when close.
		// inside deadzone: stop and reset cycle
		// by making small turns, the delay allows the machine to drive towards the line
		if (toolXTE_cm > -deadZone && toolXTE_cm < deadZone)
		{
			pwmDrive = steerStop;
			steerStarted = 0;
			steerPaused = 0;
			isPausing = false;
		}
		else
		{
			// pause phase
			if (isPausing)
			{
				pwmDrive = steerStop;

				if (steerPaused >= steerGapTime)
				{
					isPausing = false;
					steerStarted = 0; // start a fresh steer pulse
				}
			}

			// steer phase
			if (!isPausing)
			{
				if (steerStarted < steerMaxTime && 
						actuatorPositionPercent < toolSettings.maxActuatorLimit && 
						actuatorPositionPercent > -toolSettings.maxActuatorLimit)
				{
					pwmDrive = (toolXTE_cm > deadZone) ? steerLeft : steerRight;
				}
				else
				{
					// this could also kick in if we hit the actuator limit, which would be good to prevent damage or clamp wild oscillations
					pwmDrive = steerStop;
					steerPaused = 0; // begin pause timer
					isPausing = true;
				}
			}
		}
		pwmDisplay = pwmDrive;
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
	// final correction, if steering is inverted
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
