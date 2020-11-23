Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Private A_Star_Clicked, Djik_Clicked, BFS_Clicked, DFS_Clicked As Boolean
    Private maze As New Maze

#Region " Grid "
    Private Sub SetGridSize()
        While maze.GridSize <= 0 OrElse maze.GridSize > 50
            Console.WriteLine("Enter maze size (1 - 50):")
            Dim input As String = Console.ReadLine
            If IsNumeric(input) Then maze.GridSize = CInt(input)
            Console.Clear()
        End While
    End Sub

    Private Sub RelocatePictureBox()
        AutoSize = True
        PictureBox1.Width = maze.GridSize * maze.CellSize
        PictureBox1.Height = maze.GridSize * maze.CellSize
        If maze.GridSize = 50 Then
            PictureBox1.Location = New Point(CInt(Width / 2) - CInt(PictureBox1.Width / 2), 7)
        Else
            PictureBox1.Location = New Point(CInt(Width / 2) - CInt(PictureBox1.Width / 2), CInt(Height / 2) - CInt(PictureBox1.Height / 2))
        End If
    End Sub

    Private Sub DisplayInfo(TimeTaken As Double)
        Console.WriteLine("Time taken: " & TimeTaken & "ms")
        Console.WriteLine("Number of Iterations: " & maze.Iterations)
    End Sub

    Private Function GetClickedCell(ByVal point As Point) As Cell
        Return maze.GetCell(CInt(Math.Floor(point.X / maze.CellSize)), CInt(Math.Floor(point.Y / maze.CellSize)))
    End Function

    Private Sub DrawPath(ByVal e As PaintEventArgs)
        For Each cell As Cell In maze.Cells
            For Each line As Rectangle In cell.LinePath
                e.Graphics.FillRectangle(Brushes.Goldenrod, line)
            Next
            cell.RemoveLines()
        Next
    End Sub
    Private Sub DrawMaze(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        RelocatePictureBox()

        ' Draw Cells
        For Each cell As Cell In maze.Cells
            Dim color As Brush = Brushes.White
            Select Case cell.CellType
                Case CellType.Start
                    color = Brushes.LimeGreen
                Case CellType.Finish
                    color = Brushes.OrangeRed
                Case CellType.Highlight
                    color = Brushes.Yellow
                Case CellType.Checkpoint
                    color = Brushes.CornflowerBlue
            End Select
            g.FillRectangle(color, New Rectangle(cell.X * cell.Width, cell.Y * cell.Height, cell.Width, cell.Height))
        Next

        ' Draw Grid
        For i As Integer = 0 To maze.GridSize * maze.CellSize Step maze.CellSize
            g.DrawLine(Pens.LightSlateGray, 0, i, PictureBox1.Width, i)
        Next
        For j As Integer = 0 To maze.GridSize * maze.CellSize Step maze.CellSize
            g.DrawLine(Pens.LightSlateGray, j, 0, j, PictureBox1.Height)
        Next

        ' Draw Passages
        For Each passage As Rectangle In maze.Passages
            g.FillRectangle(Brushes.White, passage)
        Next

        For Each cell As Cell In maze.Cells
            ' Black dots
            g.FillRectangle(Brushes.Black, New Rectangle((cell.X * cell.Width) - 1, (cell.Y * cell.Height) - 1, 3, 3))
            g.FillRectangle(Brushes.Black, New Rectangle((cell.X * cell.Width) + cell.Width - 1, (cell.Y * cell.Height) - 1, 3, 3))
            g.FillRectangle(Brushes.Black, New Rectangle((cell.X * cell.Width) - 1, (cell.Y * cell.Height) + cell.Height - 1, 3, 3))
            g.FillRectangle(Brushes.Black, New Rectangle((cell.X * cell.Width) + cell.Width - 1, (cell.Y * cell.Height) + cell.Height - 1, 3, 3))
        Next

        Console.ForegroundColor = ConsoleColor.Green
        Dim TimeTaken As Double
        maze.Iterations = 0
        'Try
        If A_Star_Clicked Then
                A_Star_Clicked = False
                Console.Clear()
                Dim Timer = Now
                maze.Iterations = 0
                maze.FindAStarPath()
                DrawPath(e)
                TimeTaken = (Now - Timer).TotalMilliseconds
                DisplayInfo(TimeTaken)

            ElseIf Djik_Clicked Then
                Djik_Clicked = False
                Console.Clear()
                Dim Timer = Now
                maze.Iterations = 0
                maze.FindDijkstraPath()
                DrawPath(e)
                TimeTaken = (Now - Timer).TotalMilliseconds
                DisplayInfo(TimeTaken)

            ElseIf BFS_Clicked Then
                BFS_Clicked = False
                Console.Clear()
                Dim Timer = Now
                maze.Iterations = 0
                maze.FindBFSPath()
                DrawPath(e)
                TimeTaken = (Now - Timer).TotalMilliseconds
                DisplayInfo(TimeTaken)

            ElseIf DFS_Clicked Then
                DFS_Clicked = False
                Console.Clear()
                Dim Timer = Now
                maze.Iterations = 0
                maze.FindDFSPath()
                DrawPath(e)
                TimeTaken = (Now - Timer).TotalMilliseconds
                DisplayInfo(TimeTaken)
            End If
        'Catch ex As NullReferenceException
        '    MessageBox.Show("Please Set The Start/Finish Cell.", "Error!")
        'End Try
        Console.ResetColor()
    End Sub
#End Region

#Region " Event handlers "
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        SolveButton.Hide()
        DjikButton.Hide()
        aStarButton.Hide()
        BFSButton.Hide()
        DFSButton.Hide()
        CenterToScreen()
        SetGridSize()
        HelpBox.AppendText("
Left Click:
Set Start Cell

Right Click:
Set Finish Cell

Middle Click:
Set Checkpoint
")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        If maze.Cells.Count > 0 AndAlso e.Button = MouseButtons.Middle Then
            'maze.ClearHighlight()
            'With GetClickedCell(New Point(e.X, e.Y))
            '    .HighlightNeighbours()
            'End With
            maze.SetCheckpoint(GetClickedCell(New Point(e.X, e.Y)))
        ElseIf maze.Cells.Count > 0 AndAlso e.Button = MouseButtons.Right Then
            maze.SetFinishCell(GetClickedCell(New Point(e.X, e.Y)))
        ElseIf maze.Cells.Count > 0 AndAlso e.Button = MouseButtons.Left Then
            maze.SetStartCell(GetClickedCell(New Point(e.X, e.Y)))
        End If
        PictureBox1.Refresh()
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles PictureBox1.Paint
        DrawMaze(e)
    End Sub

    Private Sub GenerateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GenerateButton.Click
        maze.GenerateMaze()
        SolveButton.Show()
        PictureBox1.Refresh()
    End Sub

    Private Sub Solve(sender As Object, e As EventArgs) Handles SolveButton.Click
        aStarButton.Show()
        DjikButton.Show()
        BFSButton.Show()
        DFSButton.Show()
    End Sub

    Private Sub DjikButton_Click(sender As Object, e As EventArgs) Handles DjikButton.Click
        Djik_Clicked = True
        PictureBox1.Refresh()
    End Sub

    Private Sub aStarButton_Click(sender As Object, e As EventArgs) Handles aStarButton.Click
        A_Star_Clicked = True
        PictureBox1.Refresh()
    End Sub

    Private Sub BFSButton_Click(sender As Object, e As EventArgs) Handles BFSButton.Click
        BFS_Clicked = True
        PictureBox1.Refresh()
    End Sub

    Private Sub ClearCheckPts_Click(sender As Object, e As EventArgs) Handles ClearCheckPts.Click
        maze.ClearCheckpoints()
        PictureBox1.Refresh()
    End Sub

    Private Sub DFSButton_Click(sender As Object, e As EventArgs) Handles DFSButton.Click
        DFS_Clicked = True
        PictureBox1.Refresh()
    End Sub

    Private Sub ResetSizeButton_Click(sender As Object, e As EventArgs) Handles ResetSizeButton.Click
        maze.GridSize = -1
        SetGridSize()
        maze.GenerateMaze()
        RelocatePictureBox()
        PictureBox1.Refresh()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
    End Sub
#End Region

End Class

#Region " Classes and Enums "

Public Class Cell
    Public Property Passages As New List(Of Direction)
    Public Property CellType As CellType
    Public Property Neighbours As New List(Of Cell)
    Public Property Visited As Boolean
    Public Property X As Integer
    Public Property Y As Integer
    Public Property Width As Integer
    Public Property Height As Integer
    Public Property LinePath As New List(Of Rectangle)

#Region " Pathfinding Properties/Methods "
    Public Property F As Decimal    'Total cost
    Public Property G As Decimal    'Cost of moving from start cell to current cell
    Public Property H As Decimal    'Cost of moving from current cell to finish cell 
    Public Property Parent As Cell

    Public Sub CalculateH(start As Cell, finish As Cell)
        H = Math.Abs(start.X - finish.X) + Math.Abs(start.Y - finish.Y)
    End Sub

    Public Sub UpdateFandG(currentCellG As Decimal, distance As Decimal)
        G = currentCellG + distance
        F = G + H
    End Sub
#End Region

    Public Sub RemoveLines()
        Dim index As Integer
        For i = 0 To LinePath.Count - 1
            LinePath.RemoveAt(index)
            index = LinePath.Count - 1
        Next
    End Sub

    Public Sub AddNeighbour(cell As Cell)
        If Not Neighbours.Contains(cell) Then
            Neighbours.Add(cell)
            cell.AddNeighbour(Me)
        End If
    End Sub

    Public Sub HighlightNeighbours()
        If CellType = CellType.Path Then CellType = CellType.Highlight
        For Each c As Cell In Neighbours
            If c.CellType = CellType.Path Then c.CellType = CellType.Highlight
        Next
    End Sub
End Class

Class Maze
    Public Property GridSize As Integer
    Public Property Cells As New List(Of Cell)
    Public Property CellSize As Integer = 20
    Public Property Passages As New List(Of Rectangle)
    Public Property Iterations As Integer
    Private random As New Random

    Public Sub FindDFSPath()
        Dim finishCell As Cell = GetFinishCell()
        Dim startCell As Cell = GetStartCell()
        Dim Stack As New Stack(Of Cell)
        Dim currentcell As Cell
        Dim checkpoints As List(Of Cell) = GetCheckpoints()
        Dim openSet As New List(Of Cell)

        If Iterations = 0 Then
            For Each cell In Cells
                cell.Parent = Nothing
                openSet.Add(cell)
            Next
        End If

        Stack.Push(startCell)
        openSet.Remove(startCell)

        While Stack.Count > 0
            Iterations += 1
            currentcell = Stack.Pop
            If currentcell Is finishCell Then
                AddLines(currentcell)
                If checkpoints.Count = 0 Then
                    Return
                End If
            ElseIf checkpoints.Contains(currentcell) Then
                checkpoints.Remove(currentcell)
                AddLines(currentcell)
            End If

            For Each neighbour In currentcell.Neighbours
                    If openSet.Contains(neighbour) Then
                        Stack.Push(neighbour)
                        openSet.Remove(neighbour)
                        neighbour.Parent = currentcell
                    End If
                Next
        End While

    End Sub

    Public Sub FindBFSPath()
        Dim finishCell As Cell = GetFinishCell()
        Dim startCell As Cell = GetStartCell()
        Dim Queue As New Queue(Of Cell)
        Dim currentcell As Cell
        Dim checkpoints As List(Of Cell) = GetCheckpoints()
        Dim openSet As New List(Of Cell)

        If Iterations = 0 Then
            For Each cell In Cells
                cell.Parent = Nothing
                openSet.Add(cell)
            Next
        End If

        openSet.Remove(startCell)
        Queue.Enqueue(startCell)

        While Queue.Count > 0
            Iterations += 1
            currentcell = Queue.Dequeue
            If currentcell Is finishCell Then
                AddLines(currentcell)
                If checkpoints.Count = 0 Then
                    Return
                End If
            ElseIf checkpoints.Contains(currentcell) Then
                checkpoints.Remove(currentcell)
                AddLines(currentcell)
            End If
            For Each neighbour As Cell In currentcell.Neighbours
                If openSet.Contains(neighbour) Then
                    openSet.Remove(neighbour)
                    Queue.Enqueue(neighbour)
                    neighbour.Parent = currentcell
                End If
            Next
        End While

    End Sub

    Public Sub FindDijkstraPath()
        Dim openSet As New List(Of Cell)
        Dim closedSet As New List(Of Cell)
        Dim finishCell As Cell = GetFinishCell()
        Dim startCell As Cell = GetStartCell()
        Dim checkpoints As List(Of Cell) = GetCheckpoints()
        Dim infinity As Integer = Integer.MaxValue
        Dim currentcell As Cell


        If Iterations = 0 Then
            For Each cell In Cells
                cell.G = infinity
                cell.Parent = Nothing
                openSet.Add(cell)
            Next
        End If
        startCell.G = 0

        While openSet.Count > 0
            Iterations += 1
            currentcell = MinDistanceCell(openSet)
            openSet.Remove(currentcell)
            closedSet.Add(currentcell)

            If currentcell Is finishCell Then
                AddLines(currentcell)
                If checkpoints.Count = 0 Then
                    Return
                End If
            ElseIf checkpoints.Contains(currentcell) Then
                checkpoints.Remove(currentcell)
                AddLines(currentcell)
            End If

            For Each neighbour As Cell In currentcell.Neighbours
                If openSet.Contains(neighbour) Then
                    If currentcell.G + 1 < neighbour.G Then
                        neighbour.G = currentcell.G + 1
                        neighbour.Parent = currentcell
                    End If
                End If
            Next
        End While
    End Sub

    Public Sub FindAStarPath()
        Dim openList As New List(Of Cell)
        Dim closedList As New List(Of Cell)
        Dim finishCell As Cell = GetFinishCell()
        Dim startCell As Cell = GetStartCell()
        Dim checkpoints As List(Of Cell) = GetCheckpoints()
        openList.Add(startCell)
        startCell.CalculateH(startCell, finishCell)

        While openList.Count > 0
            Dim currentCell As Cell = Nothing
            Iterations += 1
            For Each c As Cell In openList
                If currentCell Is Nothing OrElse c.F < currentCell.F Then
                    currentCell = c
                End If
            Next

            If currentCell Is finishCell Then
                AddLines(currentCell)
                If checkpoints.Count = 0 Then
                    Return
                End If
            ElseIf checkpoints.Contains(currentCell) Then
                checkpoints.Remove(currentCell)
                AddLines(currentCell)
            End If

            openList.Remove(currentCell)
            closedList.Add(currentCell)

            For Each cell As Cell In currentCell.Neighbours
                If Not closedList.Contains(cell) Then
                    If checkpoints.Count = 0 Then
                        cell.CalculateH(currentCell, finishCell)
                    Else
                        cell.CalculateH(currentCell, ClosestCheckpoint(checkpoints, currentCell))
                    End If

                    ' distance parameter hardcoded to 1 because every neighbour is 1 cell away
                    cell.UpdateFandG(currentCell.G, 1)

                    If openList.Contains(cell) Then
                        ' update parent if faster route found
                        If currentCell.G + 1 < cell.G Then
                            cell.UpdateFandG(currentCell.G, 1)
                            cell.Parent = currentCell
                        End If
                    Else
                        openList.Add(cell)
                        cell.UpdateFandG(currentCell.G, 1)
                        cell.Parent = currentCell
                    End If
                End If
            Next

        End While

    End Sub

    Public Function ClosestCheckpoint(checkpoints As List(Of Cell), currentCell As Cell) As Cell
        Dim Closest = New Cell With {.H = Integer.MaxValue}
        For Each checkpoint In checkpoints
            currentCell.CalculateH(currentCell, checkpoint)
            If currentCell.H < Closest.H Then
                Closest = checkpoint
            End If
        Next
        Return Closest
    End Function

    Public Function MinDistanceCell(ByVal openSet As List(Of Cell)) As Cell
        Dim MinDistCell = New Cell With {.G = Integer.MaxValue}
        For Each cell In openSet
            If cell.G < MinDistCell.G Then
                MinDistCell = cell
            End If
        Next
        Return MinDistCell
    End Function

    Public Sub AddLines(ByVal currentCell As Cell)
        While currentCell.CellType <> CellType.Start
            Dim line As Rectangle
            If currentCell.Parent.Y = currentCell.Y Then
                If currentCell.Parent.X < currentCell.X Then
                    line = New Rectangle((currentCell.Parent.X * CellSize) + 10, (currentCell.Y * CellSize) + 10, CellSize, 3)
                Else
                    line = New Rectangle((currentCell.X * CellSize) + 10, (currentCell.Y * CellSize) + 10, CellSize + 3, 3)
                End If
            ElseIf currentCell.Parent.X = currentCell.X Then
                If currentCell.Parent.Y < currentCell.Y Then
                    line = New Rectangle((currentCell.X * CellSize) + 10, (currentCell.Parent.Y * CellSize) + 10, 3, CellSize)
                Else
                    line = New Rectangle((currentCell.X * CellSize) + 10, (currentCell.Y * CellSize) + 10, 3, CellSize + 3)
                End If
            End If
            currentCell.LinePath.Add(line)
            currentCell = currentCell.Parent
        End While
    End Sub

    Public Function GetCell(x As Integer, y As Integer) As Cell
        Return Cells.Find(Function(c) c.X = x AndAlso c.Y = y)
    End Function

    Public Sub ClearHighlight()
        For Each c As Cell In Cells
            If c.CellType = CellType.Highlight Then c.CellType = CellType.Path
        Next
    End Sub

    Private Sub UpdateLogicMap()
        For Each cell As Cell In Cells
            For Each Direction As Direction In cell.Passages
                Select Case Direction
                    Case Direction.North
                        cell.AddNeighbour(GetCell(cell.X, cell.Y - 1))
                    Case Direction.East
                        cell.AddNeighbour(GetCell(cell.X + 1, cell.Y))
                    Case Direction.South
                        cell.AddNeighbour(GetCell(cell.X, cell.Y + 1))
                    Case Direction.West
                        cell.AddNeighbour(GetCell(cell.X - 1, cell.Y))
                End Select
            Next
        Next
    End Sub

    Public Sub GenerateMaze()
        Dim unvisitedCells As New List(Of Cell)
        Dim visitedCells As New List(Of Cell)
        Passages.Clear()
        Cells.Clear()

        For i As Integer = 0 To GridSize - 1
            For j As Integer = 0 To GridSize - 1
                unvisitedCells.Add(New Cell() With {.X = j, .Y = i, .Width = CellSize, .Height = CellSize, .CellType = CellType.Path})
            Next
        Next
        Cells.Add(unvisitedCells.First)

        visitedCells.Add(unvisitedCells.First)
        unvisitedCells.RemoveAt(0)
        Dim currentCell As Cell = visitedCells.First
        currentCell.Visited = True

        Dim backTrack As Integer = 1

        While unvisitedCells.Count > 0
            Dim indices As New List(Of Integer)
            indices.Add(unvisitedCells.FindIndex(Function(c) c.X = currentCell.X And c.Y = currentCell.Y - 1)) 'top
            indices.Add(unvisitedCells.FindIndex(Function(c) c.X = currentCell.X + 1 And c.Y = currentCell.Y)) 'right
            indices.Add(unvisitedCells.FindIndex(Function(c) c.X = currentCell.X And c.Y = currentCell.Y + 1)) 'bottom
            indices.Add(unvisitedCells.FindIndex(Function(c) c.X = currentCell.X - 1 And c.Y = currentCell.Y)) 'left
            indices.RemoveAll(Function(x) x = -1)

            If indices.Count > 0 Then
                Dim index As Integer = indices(random.Next(0, indices.Count))

                If currentCell.X > unvisitedCells(index).X Then 'left
                    Passages.Add(New Rectangle(currentCell.X * CellSize - 1, currentCell.Y * CellSize + 2, 3, 17))
                    currentCell.Passages.Add(Direction.West)
                ElseIf currentCell.X < unvisitedCells(index).X Then 'right
                    Passages.Add(New Rectangle(unvisitedCells(index).X * CellSize - 1, currentCell.Y * CellSize + 2, 3, 17))
                    currentCell.Passages.Add(Direction.East)
                ElseIf currentCell.X = unvisitedCells(index).X Then
                    If currentCell.Y > unvisitedCells(index).Y Then 'top
                        Passages.Add(New Rectangle(currentCell.X * CellSize + 2, currentCell.Y * CellSize - 1, 17, 3))
                        currentCell.Passages.Add(Direction.North)
                    ElseIf currentCell.Y < unvisitedCells(index).Y Then 'bottom
                        Passages.Add(New Rectangle(currentCell.X * CellSize + 2, unvisitedCells(index).Y * CellSize - 1, 17, 3))
                        currentCell.Passages.Add(Direction.South)
                    End If
                End If

                visitedCells.Add(unvisitedCells(index))
                unvisitedCells.RemoveAt(index)
                currentCell = visitedCells.Last
                currentCell.Visited = True
                backTrack = 1
            Else
                currentCell = visitedCells(visitedCells.Count - (1 + backTrack))
                backTrack += 1
            End If

            If Not Cells.Contains(currentCell) Then Cells.Add(currentCell)
        End While
        UpdateLogicMap()
    End Sub

    Public Sub SetFinishCell(ByVal finishCell As Cell)
        For Each c As Cell In Cells
            If c.CellType = CellType.Finish Then c.CellType = CellType.Path
        Next
        GetCell(finishCell.X, finishCell.Y).CellType = CellType.Finish
    End Sub

    Public Sub SetStartCell(ByVal startCell As Cell)
        For Each c As Cell In Cells
            If c.CellType = CellType.Start Then c.CellType = CellType.Path
        Next
        GetCell(startCell.X, startCell.Y).CellType = CellType.Start
    End Sub

    Public Sub SetCheckpoint(ByVal checkpoint As Cell)
        GetCell(checkpoint.X, checkpoint.Y).CellType = CellType.Checkpoint
    End Sub

    Public Function GetCheckpoints() As List(Of Cell)
        Dim checkpoints As New List(Of Cell)
        For i = 0 To Cells.Count - 1
            If Cells(i).CellType = CellType.Checkpoint Then
                checkpoints.Add(Cells(i))
            End If
        Next
        Return checkpoints
    End Function

    Public Sub ClearCheckpoints()
        For Each c As Cell In Cells
            If c.CellType = CellType.Checkpoint Then c.CellType = CellType.Path
        Next
    End Sub

    Private Function GetFinishCell() As Cell
        Return Cells.Find(Function(c) c.CellType = CellType.Finish)
    End Function

    Public Function GetStartCell() As Cell
        Return Cells.Find(Function(c) c.CellType = CellType.Start)
    End Function
End Class

Public Enum CellType As Integer
    Start = 1
    Finish = 2
    Path = 3
    Highlight = 4
    Checkpoint = 5
End Enum

Public Enum Direction As Integer
    North = 1
    East = 2
    South = 3
    West = 4
End Enum
#End Region





