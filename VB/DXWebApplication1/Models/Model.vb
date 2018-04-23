

Public Class InMemoryModel
    Const DataItemsCount As Integer = 100

    Public Property ID() As Integer
        Get
            Return m_ID
        End Get
        Set(value As Integer)
            m_ID = value
        End Set
    End Property
    Private m_ID As Integer
    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set(value As String)
            m_Text = value
        End Set
    End Property
    Private m_Text As String
    Public Property Quantity() As Integer
        Get
            Return m_Quantity
        End Get
        Set(value As Integer)
            m_Quantity = value
        End Set
    End Property
    Private m_Quantity As Integer
    Public Property Price() As Decimal
        Get
            Return m_Price
        End Get
        Set(value As Decimal)
            m_Price = value
        End Set
    End Property
    Private m_Price As Decimal

    Public Shared Function GetTypedListModel() As List(Of InMemoryModel)
        Dim typedList As New List(Of InMemoryModel)()

        Dim randomizer As New Random()

        For index As Integer = 0 To DataItemsCount - 1
            Dim m As New InMemoryModel()
            m.ID = index
            m.Text = "Text" + index.ToString()
            m.Quantity = randomizer.[Next](1, 50)
            m.Price = CDec(Math.Round((randomizer.NextDouble() * 100), 2))
            typedList.Add(m)
        Next
        Return typedList
    End Function
End Class


