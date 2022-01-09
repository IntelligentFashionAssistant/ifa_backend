#!/usr/bin/env python3

import pyodbc

def main():
    # Specifying the ODBC driver, server name, database, etc. directly
    conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER=localhost,1433;DATABASE=master;UID=SA;PWD=Aamm-1970'
                          , autocommit=True)
    # Create a cursor from the connection
    backup = "BACKUP DATABASE [mydb] TO DISK = N'IFA.bak'"
    cursor = conn.cursor().execute(backup)
    while cursor.nextset():
        pass
    conn.close()

if __name__ == '__main__':
    main()
