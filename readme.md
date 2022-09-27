# About Project:

# Folders:

- `DbInitFile` : Contains the backup for Database. This need to be restored to SQL Server to create the Database used by the Application
- `HiveMind` : Contains the application code.
- `HiveMindTest` : Contains the test cases for HiveMind Application.

# Process to Setup Application:

## Configuration :

- The application work on either authenitcation using XML Store or Database Store. The mode needs to be specified in `web.config` file:

### XML Based

- Set Up "AuthenticationType" as "XML" in app settings.
- Set Up data store location in "LoginFileLocation" in app settings. This should point to the absolute path of "HiveMind\data\login_data.xml".
  ![XML](https://github.com/MaddyUnknown/HiveMind-Concept/HiveMind/asset/imag/readmeSS/xmlconfig.png)

### DB Based

- Set Up "AuthenticationType" as "DB" in app settings.
- Set Up data connection string named "userlogincon".
- **Note** : To use this feature, SQL Server instance needs to be set up. This is describe in subsequent steps.
  ![DB](https://github.com/MaddyUnknown/HiveMind-Concept/HiveMind/asset/imag/readmeSS/Dbconfig.png)

## Database Setup:

- Restore the database in SQL Server using the backup in `DbInitFile\HiveMindDb.bak` file. This will create all the necessary table for the authentication to work.
- **Note** : Seperate user can be created for accessing the database. If created, connection string needs to be configured accordingly.
