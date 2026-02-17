
#define steerLeft -255
#define steerRight 255
#define steerStop 0
elapsedMillis steerStarted = 0;
elapsedMillis steerPaused = 0;

float steerGapTime = toolSettings.kp * 10; // kp/pgain * ms between steering changes
float steerMaxTime = toolSettings.ki * 10; // ki/integral * ms maximum time to hold a steer

// so 500/500 will be half second on/off, pulses, 50% duty. PWM, in effect

float deadZone = toolSettings.maxPWM / 10; // cm of XTE where we do not steer

// float kP = toolSettings.Kp / 10;					  	// (prop gain in TWOL) steering gain (deg per cm - start at 0.25)
// float maxSteer = toolSettings.maxActuatorLimit;     	// (obv) absolute steering limit (eg 5)
// float lowXteZone = toolSettings.Ki / 10;			  	// (Integral in TWOL) cm where we soften response (eg 5)
// float minAuthority = toolSettings.highPWM / 10;		// deg allowed near center

// float kP = toolSettings.Kp / 10;					  	// (prop gain in TWOL) steering gain (deg per cm - start at 0.25)
// float maxSteer = toolSettings.maxActuatorLimit;     	// (obv) absolute steering limit (eg 5)
// float lowXteZone = toolSettings.Ki / 10;			  	// (Integral in TWOL) cm where we soften response (eg 5)
// float minAuthority = toolSettings.highPWM / 10;		// deg allowed near center

void calcSteeringPID(void)
{

	if (toolSettings.isBangBang)
	{
		static bool isPausing = false;

		// inside deadzone: stop and reset cycle
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
				if (steerStarted < steerMaxTime)
				{
					pwmDrive = (toolXTE_cm > deadZone) ? steerLeft : steerRight;
				}
				else
				{
					pwmDrive = steerStop;
					steerPaused = 0; // begin pause timer
					isPausing = true;
				}
			}
		}
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
