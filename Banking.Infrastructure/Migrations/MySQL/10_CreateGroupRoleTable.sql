CREATE TABLE group_role(
  group_role_id BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  group_id SMALLINT(6) UNSIGNED NOT NULL,
  role_id SMALLINT(6) UNSIGNED NOT NULL,  
  active BIT NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(group_role_id),
  UNIQUE INDEX UQ_group_role_group_id_role_id(group_id, role_id),
  INDEX IX_group_role_group_id(group_id),
  INDEX IX_group_role_role_id(role_id),
  CONSTRAINT FK_group_role_group_id FOREIGN KEY(group_id) REFERENCES `group`(group_id),
  CONSTRAINT FK_group_role_role_id FOREIGN KEY(role_id) REFERENCES role(role_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;