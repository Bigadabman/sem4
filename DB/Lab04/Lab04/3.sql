USE UNIVER;

SELECT FACULTY.FACULTY_NAME, PULPIT.PULPIT_NAME, PROFESSION.PROFESSION_NAME , SUBJECT.SUBJECT_NAME, STUDENT.NAME,

CASE 
WHEN (PROGRESS.NOTE = 6) THEN '�����'
WHEN PROGRESS.NOTE = 7 THEN '����'
WHEN PROGRESS.NOTE = 8 THEN '������'
else '������'
END [NOTE]
FROM PROGRESS INNER JOIN STUDENT ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT,
SUBJECT, PULPIT, GROUPS, FACULTY, PROFESSION

WHERE SUBJECT.SUBJECT = PROGRESS.SUBJECT
AND SUBJECT.PULPIT = PULPIT.PULPIT
AND STUDENT.IDGROUP = GROUPS.IDGROUP
AND GROUPS.FACULTY = FACULTY.FACULTY
AND GROUPS.PROFESSION = PROFESSION.PROFESSION
AND PROGRESS.NOTE BETWEEN 6 AND 8
ORDER BY PROGRESS.NOTE DESC;
