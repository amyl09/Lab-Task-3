Public Class appList
    'set the maximum capacity for the array
    Private maxCapacity As Integer = 4
    Private apps(maxCapacity - 1) As String
    Private appCount As Integer = 0

    'display messagebox info so that user know what to do first
    Private Sub appList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("Please add the apps first", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'clear the listboxapps 
    Private Sub clearList()
        ListBoxApps.Items.Clear()
    End Sub
    Private Sub DisplayApps()
        'display the current apps in a listApp 
        ListBoxApps.Items.Clear()

        For i As Integer = 0 To appCount - 1
            ListBoxApps.Items.Add(apps(i))
        Next
    End Sub

    Private Sub AddApp(appName As String)
        'check if there is space in the array
        If appCount < maxCapacity Then
            'add the app to the array
            apps(appCount) = appName
            appCount += 1
            MessageBox.Show($"{appName} has been added to the list.", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Array is full! Cannot add more apps.", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'get the app name from the user
        Dim appName As String = InputBox("Enter the name of the app: ")

        'check if the user entered a name
        If Not String.IsNullOrEmpty(appName) Then
            'add the app to the array
            addApp(appName)

            'display the updated list of apps
            DisplayApps()
            clearList()
        Else
            MessageBox.Show("Please enter a valid app name.", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        'display the list of all installed apps
        DisplayApps()
    End Sub

    Private Sub UpdateApp(index As Integer, newName As String)
        'update the app at the specified index with the new name
        apps(index) = newName
        MessageBox.Show($"The app is successfully updated! New app name: {newName}", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'allow the user to select an app to update
        Dim selectedAppIndex As Integer = ListBoxApps.SelectedIndex

        If selectedAppIndex <> -1 Then
            'get the new name for the app
            Dim newAppName As String = InputBox($"Enter the new name for the app: ")

            'check if the user entered a new name
            If Not String.IsNullOrEmpty(newAppName) Then
                'update the selected app with the new name
                UpdateApp(selectedAppIndex, newAppName)

                'display the updated list of apps
                DisplayApps()
            Else
                MessageBox.Show("Please enter a valid new app name.", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Please select an app to updated.", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DeleteApp(index As Integer)
        'remove the app at the specified index
        Dim removedAppName As String = apps(index)
        Dim confirmsg = MessageBox.Show($"Are you sure to deleted {removedAppName}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmsg = DialogResult.Yes Then
            'shift the remaining elements to fill the gap
            For i As Integer = index To appCount - 2
                apps(i) = apps(i + 1)
            Next

            'decrement the app count
            appCount -= 1
            MessageBox.Show($"{removedAppName} app has been deleted from the list.")
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'allow the user to select an app to remove
        Dim selectedAppIndex As Integer = ListBoxApps.SelectedIndex

        If selectedAppIndex <> -1 Then
            'remove the selected app
            DeleteApp(selectedAppIndex)

            'display the updated list of apps
            DisplayApps()
        Else
            MessageBox.Show("Please select an app to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub linkExit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkExit.LinkClicked
        Application.Exit()
    End Sub
End Class