CREATE TABLE user_role(
  user_role_id BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  user_id BIGINT(20) UNSIGNED NOT NULL,
  role_id SMALLINT(6) UNSIGNED NOT NULL,  
  active BIT NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(user_role_id),
  UNIQUE INDEX UQ_user_role_user_id_role_id(user_id, role_id),
  INDEX IX_user_role_user_id(user_id),
  INDEX IX_user_role_role_id(role_id),
  CONSTRAINT FK_user_role_user_id FOREIGN KEY(user_id) REFERENCES user(user_id),
  CONSTRAINT FK_user_role_role_id FOREIGN KEY(role_id) REFERENCES role(role_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;