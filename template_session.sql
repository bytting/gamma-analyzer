CREATE TABLE `session` (
	`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`name` TEXT NOT NULL UNIQUE,
	`comment` TEXT,
	`livetime` REAL NOT NULL,
	`detector_data` TEXT NOT NULL,
	`detector_type_data` TEXT NOT NULL
);

CREATE TABLE `spectrums` (
	`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`session_id` INTEGER NOT NULL,
	`session_name` TEXT NOT NULL,
	`session_index` INTEGER NOT NULL UNIQUE,
	`start_time` TEXT NOT NULL,
	`latitude` REAL NOT NULL,
	`latitude_error` REAL NOT NULL,
	`longitude` REAL NOT NULL,
	`longitude_error` REAL NOT NULL,
	`altitude` REAL NOT NULL,
	`altitude_error` REAL NOT NULL,
	`track` REAL NOT NULL,
	`track_error` REAL NOT NULL,
	`speed` REAL NOT NULL,
	`speed_error` REAL NOT NULL,
	`climb` REAL NOT NULL,
	`climb_error` REAL NOT NULL,
	`livetime` REAL NOT NULL,
	`realtime` REAL NOT NULL,
	`total_count` INTEGER NOT NULL,
	`num_channels` INTEGER NOT NULL,
	`channels` TEXT NOT NULL
);