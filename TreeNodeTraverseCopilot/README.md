# TreeNodeTraverseCopilot

## Overview

TreeNodeTraverseCopilot is an ASP.NET Web Forms project that demonstrates a flexible, attribute-driven access control system for disabling or enabling controls based on user permissions (read-only or read/write). The solution supports both pages and user controls, allowing fine-grained control over which UI elements are editable for different user roles.

## Features

- **Centralized Access Control:**  
  Uses a base class (`AccessControlBase`) to determine user access and recursively disable controls for read-only users.
- **Attribute-Driven Exceptions:**  
  Mark controls that should remain enabled in read-only mode with the `[AllowIfReadOnly]` attribute via a property in the code-behind.
- **Works with Pages and UserControls:**  
  Inherit from `BasePage` or `BaseUserControl` to automatically apply access logic.
- **Extensible:**  
  Easily integrate with your own database logic to determine user permissions.

## Usage

### 1. Inherit from the Base Classes

- For pages, inherit from `BasePage`.
- For user controls, inherit from `BaseUserControl`.

### 2. Mark Controls to Allow in Read-Only Mode

For designer-generated controls, create a property in your code-behind and decorate it with `<AllowIfReadOnly>`:

```vbnet
<AllowIfReadOnly>
Protected ReadOnly Property AllowedBtnSearch As Button
    Get
        Return btnSearch
    End Get
End Property
```

### 3. Customize User Access Logic

Edit `AccessControlBase.IsUserReadOnly(userName As String)` to query your database and determine if the user should have read-only access.

### 4. Automatic Disabling

All controls (TextBox, Button, DropDownList, etc.) will be disabled for read-only users, except those marked with the attribute.

## Project Structure

- `Models/AccessControlBase.vb` – Access control logic and attribute definition.
- `Models/BasePage.vb` – Base page class for access control.
- `UserControls/GridUserControl.ascx(.vb)` – Example user control with attribute usage.
- `Pages/MainPage.aspx(.vb)` – Example page.

## How It Works

On page or user control load, the access logic checks the user’s permissions and disables controls as needed. Controls marked with `[AllowIfReadOnly]` remain enabled, allowing for search or navigation even in read-only mode.

## Customization

- Extend the attribute or logic to support more control types as needed.
- Integrate with your authentication and authorization system for real user/group checks.
