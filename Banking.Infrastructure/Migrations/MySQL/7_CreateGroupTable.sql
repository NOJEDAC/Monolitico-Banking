CREATE TABLE `group`(
  group_id SMALLINT(6) UNSIGNED NOT NULL AUTO_INCREMENT,
  group_name VARCHAR(100) NOT NULL,
  active BIT NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(group_id),
  UNIQUE INDEX UQ_group_name(group_name)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;