CREATE TABLE role(
  role_id SMALLINT(6) UNSIGNED NOT NULL AUTO_INCREMENT,
  user_id BIGINT(20) UNSIGNED NOT NULL,
  role_name VARCHAR(100) NOT NULL,
  active BIT NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(role_id),
  UNIQUE INDEX UQ_role_name(role_name),  
  CONSTRAINT FK_role_user_id FOREIGN KEY(user_id) REFERENCES user(user_id),
  CONSTRAINT FK_role_role_id FOREIGN KEY(role_id) REFERENCES role_permission(role_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;