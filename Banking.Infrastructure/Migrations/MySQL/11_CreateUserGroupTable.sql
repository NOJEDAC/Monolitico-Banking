CREATE TABLE user_group(
  user_group_id BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  user_id BIGINT(20) UNSIGNED NOT NULL,
  group_id SMALLINT(6) UNSIGNED NOT NULL,
  active BIT NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(user_group_id),
  UNIQUE INDEX UQ_user_group_user_id_group_id(user_id, group_id),
  INDEX IX_user_role_user_id(user_id),
  INDEX IX_user_role_group_id(group_id),
  CONSTRAINT FK_user_group_user_id FOREIGN KEY(user_id) REFERENCES user(user_id),
  CONSTRAINT FK_user_group_group_id FOREIGN KEY(group_id) REFERENCES `group`(group_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;