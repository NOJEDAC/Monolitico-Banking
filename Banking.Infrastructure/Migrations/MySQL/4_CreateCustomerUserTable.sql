CREATE TABLE customer_user(
  customer_user_id BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  customer_id BIGINT(20) UNSIGNED NOT NULL,
  user_id BIGINT(20) UNSIGNED NOT NULL,
  active BIT NOT NULL,
  created_at_utc DATETIME NOT NULL,
  updated_at_utc DATETIME NOT NULL,
  PRIMARY KEY(customer_user_id),
  UNIQUE INDEX UQ_customer_user_customer_id_user_id(customer_id, user_id),
  INDEX IX_customer_user_customer_id(customer_id),
  INDEX IX_customer_user_user_id(user_id),  
  CONSTRAINT FK_customer_user_customer_id FOREIGN KEY(customer_id) REFERENCES customer(customer_id),
  CONSTRAINT FK_customer_user_user_id FOREIGN KEY(user_id) REFERENCES user(user_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;