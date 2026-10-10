Public Class Cls_SetDateTimerPickerformat

    Public Overloads Sub fcnSetDateTimerPickerformat(ByRef DateTimePicker As DateTimePicker)
        DateTimePicker.Format = DateTimePickerFormat.Custom
        DateTimePicker.CustomFormat = "dd-MMM-yyyy"
    End Sub
End Class
