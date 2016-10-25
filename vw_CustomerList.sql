﻿SELECT INFO.*, ISNULL(CONTACT.CONTACTCNT, 0) AS 聯絡人數量, ISNULL(BANK.BANKCNT, 0) AS 銀行帳戶數量 FROM DBO.客戶資料 INFO
LEFT JOIN
(
	SELECT COUNT(*) AS CONTACTCNT, 客戶Id 
	FROM DBO.客戶聯絡人
	GROUP BY 客戶Id
) CONTACT
ON INFO.Id = CONTACT.客戶Id
LEFT JOIN
(
	SELECT COUNT(*) AS BANKCNT, 客戶Id 
	FROM DBO.客戶銀行資訊
	GROUP BY 客戶Id
) BANK
ON INFO.Id = BANK.客戶Id