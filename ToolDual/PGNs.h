enum PGNs {
	AgIOHello = 0xC8,
	SubnetChange = 0xC9,
	SubnetRequest = 0xCA,
	ToolSteerConfig = 231,
	ToolSteerSettings = 232,
	ToolSteerData = 233,
	//MachineSettings = 0xEE,
	//MachineData = 0xEF,
	//SteerConfig = 0xFB,
	//SteerSettings = 0xFC,
	//SteerData = 0xFE
};


enum toolDataIDs {
	xteLo = 5,
	xteHi = 6,
	status = 7,
	xteVehLo = 8,
	xteVehHi = 9,
	speed10 = 10,
	manualLo = 11,
	manualHi = 12,
};

enum pidSettingIDs {
	 gainP = 5,
	 integral = 6,
	 minPWM = 7,
	 highPWM = 8,
	 wasOffsetLo = 10,
	 wasOffsetHi = 11,
	 lowHighSetDistance = 12,
	 maxActuatorPosition = 13,
};

enum boardConfigIDs {
	isrelayActiveHigh = 5,
	singleInputAPOS = 6,
	cytronDriver = 7,
	invertAPOS = 11,
	maxActuatorPosition = 12
};