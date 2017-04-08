﻿SELECT dbo.APPLICATION.NAME, dbo.ISSUE.DESCRIPTION, DBO.ISSUE.LATEST_UPDATE
FROM dbo.AFFECTED RIGHT JOIN (dbo.APPLICATION INNER JOIN dbo.ISSUE ON dbo.APPLICATION.ID = dbo.ISSUE.APPLICATION_ID) ON dbo.AFFECTED.ISSUE_ID = dbo.ISSUE.ID
GROUP BY dbo.APPLICATION.NAME, dbo.ISSUE.DESCRIPTION, dbo.ISSUE.LATEST_UPDATE, dbo.ISSUE.REPORTER, dbo.ISSUE.STATUS, dbo.ISSUE.ASSIGNEE, dbo.ISSUE.ID, dbo.ISSUE.ISSUE_TRACK_ID
HAVING (((dbo.ISSUE.LATEST_UPDATE)>=GetDate())) OR (((dbo.ISSUE.STATUS)>0))
