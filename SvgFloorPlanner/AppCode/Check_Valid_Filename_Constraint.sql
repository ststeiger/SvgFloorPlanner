 
 ;WITH CTE AS 
 ( 
		   SELECT N'123' AS column_name 
	 UNION SELECT N'abc' AS column_name 
	 UNION SELECT N'def' AS column_name 
	 UNION SELECT N'hallo' AS column_name 
	 UNION SELECT N'hell\o' AS column_name 
	 UNION SELECT N'hal/lo' AS column_name 
	 UNION SELECT N'äöü' AS column_name 
	 UNION SELECT N'<' AS column_name 
	 UNION SELECT N'>' AS column_name 
	 UNION SELECT N':' AS column_name 
	 UNION SELECT N'|' AS column_name 
	 UNION SELECT N'?' AS column_name 
	 UNION SELECT N'*' AS column_name 
	 UNION SELECT NULL AS column_name 
	 UNION SELECT N'haha:ha' AS column_name 
	 UNION SELECT N'привет мир' AS column_name 
 ) 
 
 SELECT * FROM CTE 
 WHERE(Column_Name NOT LIKE (N'%[\/:*?"<>|]' + char(0) + '%') ) 
 -- OR Column_Name IS NULL 
 
-- Linux and other POSIX compatible systems, 
-- There are almost no restrictions - apart from '/' and '\0', you're allowed to use anything.-
-- Linux, OS-X: anything except null or /
-- Some characters (shell metacharacters like *?!)  
-- will cause problems in command lines and will require the filename to be appropriately quoted or escaped
-- "/" is reserved as it's the directory separator, and "\0" (the NULL character) designates the end of the string. 
-- Everything else is allowed.
-- except /dev/null/foo etc. -- since /dev/null has a POSIX-defined non-directory meaning
-- Linux filesystems such as ext2, ext3 are character-set agnostic 
-- (I think they just treat it more or less as a byte stream - only nulls and / are prohibited). 
-- This means you can store filenames in UTF-8 encoding. 
-- http://www.dwheeler.com/essays/fixing-unix-linux-filenames.html
-- | ; , ! @ # $ ( ) < > / \ " ' ` ~ { } [ ] = + & ^ 


-- Windows: anything except ASCII's control characters and \/:*?"<>|  
 
 -- In Windows, only NUL, :, and \ 
 -- but many apps restrict that further, also preventing ?, *, +, and %.
 
 -- https://msdn.microsoft.com/en-us/library/aa365247(VS.85)

-- on Windows-based desktop platforms, invalid path characters might include ASCII/Unicode characters 1 through 31, 
-- as well as quote ("), less than (<), greater than (>), pipe (|), backspace (\b), null (\0) and tab (\t)."

 
 -- ASCII 1 through 31,
 -- CON, PRN, AUX, NUL, COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7, LPT8, and LPT9.
 -- prn con
 -- NUL\.*
 

 -- Do not end a file or directory name with a space or a period. 
 -- Although the underlying file system may support such names, the Windows shell and user interface does not. 
 -- However, it is acceptable to specify a period as the first character of a name. For example, ".temp".
 