# Feature Flags in Dotnet

## Prerequsites
- Docker
- .NET Core SDK (3.1.401)

## Running the Flagr API & UI
1. Open *Windows PowerShell*
2. Run `docker run -it -p 18000:18000 checkr/flagr`
3. Navigate to *http://localhost:18000*

#### Create New Flag for .NET app integration
1. In the `Specific new flag description` input box, type `Feature Flag Admin test flag`
2. Click `Create New Flag`
3. Click on the Flag you just created from the list below
4. Enable the Flag by clicking the button on the top right in the `Flag` panel (should turn from red to green)
5. Replace the `Flag Key` with `AdminContent`
6. Click on `Save Flag`

#### Create New Variants for the Flag
1. In the `Variant Key` input box, type `AllContent`
2. Hit `Create Variant`
3. In the `Variant Key` input box, type `LimitedContent`
4. Hit `Create Variant`

#### Create New Admin Segment for the Flag
1. Click on `New Segment` in the `Segments` panel
2. Type out `Admin` as the `Segment description`
3. Drag the amount to 100
4. Click on `Create Segment`
5. Click on the edit icon for the Distribution and enable `AllContent` and drag the amount to 100 and click `Save`
6. Under Constraints, type out `IsAdmin` in the Property input box and `"true"` in the Value input box and ensure the comparison operator is `==`
7. Click on `Add Constraint`
8. Click `Save Segment Setting`

#### Create New NonAdmin Segment for the Flag
1. Click on `New Segment` in the `Segments` panel
2. Type out `NonAdmin` as the `Segment description`
3. Drag the amount to 100
4. Click on `Create Segment`
5. Click on the edit icon for the Distribution and enable `LimitedContent` and drag the amount to 100 and click `Save`
6. Under Constraints, type out `IsAdmin` in the Property input box and `"true"` in the Value input box and change the comparison operator to `!=`
7. Click on `Add Constraint`
8. Click `Save Segment Setting`

## Running the .NET application
1. Open *Windows Command Prompt*
2. Navigate to `...\feature-flag-toolkit\dotnet\FeatureFlags`
3. Run `dotnet run`
4. Navigate to `localhost:----` but replace the `-`s with the port number from the last `Now listening on: localhost:----`

#### Check for your Flag
1. Click on `Feature Flags` in the top panel
2. Ensure your Flag exists in the list and is enabled

#### Create User
1. Click on `Create User` in the top panel
2. Fill out whatever name you want and ensure `IsLoggedIn` and `IsAdmin` are both checked

#### View Admin Dashboard and verify both admin and standard content
1. Click on `Admin Dashboard` in the top panel
2. Ensure you can see the Admin Dashboard with both the admin and standard content

#### Change your user to be NonAdmin
1. Click on `Show Users` in the top panel
2. Click on `Edit` for your user
3. Uncheck `IsAdmin`

#### View Admin Dashboard and verify only standard content
1. Click on `Admin Dashboard` in the top panel
2. Ensure you can see the Admin Dashboard with only the standard content

#### Turn off Flag and verify both admin and standard content despite IsAdmin status
1. Navigate back to your Flagr UI
2. Disable your Flag
3. Naviage back to .NET app
4. Ensure you can see the Admin Dashboard with both the admin and standard content despite the status of your user's admin status

