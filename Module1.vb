Imports System.IO
Module Module1

    Structure student
        Dim id As Integer
        Dim name As String
        Dim age As Integer
        Dim mark As Integer
        Dim dept As Integer

        Public Overrides Function ToString() As String
            Return id.ToString + "," + name + "," + age.ToString + "," + mark.ToString + "," + dept.ToString


        End Function
    End Structure

    Structure teacher
        Dim id As Integer
        Dim name As String
        Dim age As Integer
        Dim salary As Double
        Dim degree As Char
        Dim dept As Integer

        Public Overrides Function ToString() As String
            Return id.ToString + "," + name + "," + age.ToString + "," + salary.ToString + "," + degree.ToString + "," + dept.ToString


        End Function
    End Structure

    Sub StuSortAge(ByRef stuList)
        For j = 1 To stuList.Count - 1
            Dim key As student
            key = stuList(j)

            Dim i = j - 1
            While i >= 0
                If stuList(i).age > key.age Then
                    stuList(i + 1) = stuList(i)
                    i = i - 1
                Else
                    Exit While
                End If
            End While
            stuList(i + 1) = key
        Next

        'Console.WriteLine(stuList.Count)
        'Console.WriteLine(stuList(0).age)

    End Sub

    Sub StuSortName(ByRef stuList)
        Dim j As Integer
        For j = 1 To stuList.Count - 1
            Dim key As student
            key = stuList(j)

            Dim i = j - 1
            While i >= 0
                If String.Compare(stuList(i).name, key.name) > 0 Then
                    stuList(i + 1) = stuList(i)
                    i = i - 1
                Else
                    Exit While

                End If
            End While

            stuList(i + 1) = key


        Next


    End Sub

    Sub Validate(ByVal str, ByRef arr)
        Console.WriteLine("i am here")
        Console.WriteLine(arr.length)


        Dim lastindex As Integer = 0
        Dim count As Integer = 0

        For i = 0 To str.length - 1
            If str(i).Equals(";"c) Or str(i).Equals(","c) Then
                arr(count) = str.Substring(lastindex, i - lastindex)
                Console.WriteLine(arr(count))
                count = count + 1
                lastindex = i + 1
            End If
        Next
        arr(count) = str.Substring(lastindex)

        For i = 0 To 4
            Console.WriteLine("I am inside validate")

            Console.WriteLine(arr(i))

        Next




    End Sub



    Sub Main()
        Dim arrSDpt1 As New List(Of student)
        Dim arrSDpt2 As New List(Of student)
        Dim arrTDpt1 As New List(Of teacher)
        Dim arrTDpt2 As New List(Of teacher)
        Dim MergeStudent1 As New List(Of student)
        Dim MergeStudent2 As New List(Of student)


        'loading student from student.txt
        Using srStudent As StreamReader = New StreamReader("studentn.txt")
            Dim line As String
            Dim temp(4) As String
            While Not srStudent.EndOfStream
                Dim stu As student
                line = srStudent.ReadLine()
                Validate(line, temp)
                'temp = line.Split(",")
                stu.id = CInt(temp(0))
                stu.name = temp(1)
                stu.age = CInt(temp(2))
                stu.mark = CInt(temp(3))
                stu.dept = CInt(temp(4))

                Console.WriteLine("i am here")
                For i = 0 To 4
                    Console.WriteLine(temp(i))

                Next
                If stu.dept = 1 Then
                    Console.WriteLine("i am adding")

                    arrSDpt1.Add(stu)
                ElseIf stu.dept = 2 Then
                    arrSDpt2.Add(stu)
                Else
                    'Console.WriteLine("loading student error: wrong department ID")

                End If
            End While

            Console.WriteLine("i am output")

            For Each item As student In arrSDpt1
                Console.WriteLine(item)
            Next
        End Using

        Console.WriteLine("------before sort-----")
        For Each item As student In arrSDpt1
            Console.WriteLine(item)
        Next

        StuSortName(arrSDpt1)
        'Console.WriteLine("------after sort-----")
        'For Each item As student In arrSDpt1
        '    Console.WriteLine(item)
        'Next

        'loading teacher from teacher.txt
        Using srTeacher As StreamReader = New StreamReader("teacher.txt")
            Dim line As String
            Dim temp(5) As String
            While Not srTeacher.EndOfStream
                Dim tea As teacher
                line = srTeacher.ReadLine()
                temp = line.Split(",")
                tea.id = CInt(temp(0))
                tea.name = temp(1)
                tea.age = CInt(temp(2))
                tea.salary = CDbl(temp(3))
                tea.degree = CChar(temp(4))
                tea.dept = CInt(temp(5))

                If tea.dept = 1 Then
                    arrTDpt1.Add(tea)
                ElseIf tea.dept = 2 Then
                    arrTDpt2.Add(tea)
                Else
                    Console.WriteLine("loading teacher error: wrong department ID")

                End If
            End While
        End Using

        'Console.WriteLine("------studentdepart1-------")
        'For Each item As student In arrSDpt1
        '    Console.WriteLine(item)
        'Next
        'Console.WriteLine("------studentdepart2-------")
        'For Each item As student In arrSDpt2
        '    Console.WriteLine(item)
        'Next
        'Console.WriteLine("------teacherdepart1-------")
        'For Each item As teacher In arrTDpt1
        '    Console.WriteLine(item)
        'Next
        'Console.WriteLine("------teacherdepart2-------")
        'For Each item As teacher In arrTDpt2
        '    Console.WriteLine(item)
        'Next

        Dim opt As Integer = 0
        Do
            Console.WriteLine("-------------menu-------------")
            Console.WriteLine("1. Add Student")
            Console.WriteLine("2. Add Teacher")
            Console.WriteLine("3. Update Student File")
            Console.WriteLine("4. Update Teacher File")
            Console.WriteLine("5. Display Student and Teacher(Depart 1)")
            Console.WriteLine("6. Display Student and Teacher(Depart 2)")
            Console.WriteLine("7. Sort by Age student1")
            Console.WriteLine("8. Sort by Name student1")
            Console.WriteLine("9. MergeStudent1(Age)")
            Console.WriteLine("10. MergeStudent2(Name)")
            Console.WriteLine("11. Quite")
            Console.WriteLine("-------------------------------")

            Dim input As String
            input = Console.ReadLine()

            opt = CInt(input)

            Select Case opt
                Case 1
                    Console.WriteLine("please enter student info(Id:Name:Age:Mark:dept)")
                    Dim line As String
                    Dim temp(4) As String
                    Dim stu As student
                    line = Console.ReadLine()
                    temp = line.Split(",")
                    stu.id = CInt(temp(0))
                    stu.name = temp(1)
                    stu.age = CInt(temp(2))
                    stu.mark = CInt(temp(3))
                    stu.dept = CInt(temp(4))
                    Console.WriteLine("i am here")
                    Console.WriteLine(stu)

                    If stu.dept = 1 Then
                        arrSDpt1.Add(stu)
                    ElseIf stu.dept = 2 Then
                        arrSDpt2.Add(stu)
                    Else
                        Console.WriteLine("Adding student error: wrong department ID")

                    End If
                    Exit Select

                Case 2
                    Console.WriteLine("please enter teacher info(Id:Name:Age:Salary:Degree:dept)")
                    Dim line As String
                    Dim temp(5) As String
                    Dim tea As teacher
                    line = Console.ReadLine()
                    temp = line.Split(",")
                    tea.id = CInt(temp(0))
                    tea.name = temp(1)
                    tea.age = CInt(temp(2))
                    tea.salary = CDbl(temp(3))
                    tea.degree = CChar(temp(4))
                    tea.dept = CInt(temp(5))
                    If tea.dept = 1 Then
                        arrTDpt1.Add(tea)
                    ElseIf tea.dept = 2 Then
                        arrTDpt2.Add(tea)
                    Else
                        Console.WriteLine("Adding teacher error: wrong department ID")

                    End If
                    Exit Select
                Case 3
                    Using swStu As StreamWriter = New StreamWriter("student.txt")
                        For Each item As student In arrSDpt1
                            swStu.WriteLine(item)

                        Next
                    End Using

                    Using swStuA As StreamWriter = File.AppendText("student.txt")
                        For Each item As student In arrSDpt2
                            swStuA.WriteLine(item)

                        Next
                    End Using
                    Exit Select


                Case 4
                    Using swTea As StreamWriter = New StreamWriter("teacher.txt")
                        For Each item As teacher In arrTDpt1
                            swTea.WriteLine(item)

                        Next
                    End Using

                    Using swTeaA As StreamWriter = File.AppendText("teacher.txt")
                        For Each item As teacher In arrTDpt2
                            swTeaA.WriteLine(item)

                        Next
                    End Using
                    Exit Select
                Case 5
                    Console.WriteLine("------studentdepart1-------")
                    For Each item As student In arrSDpt1
                        Console.WriteLine(item)
                    Next
                    Console.WriteLine("------teacherdepart1-------")
                    For Each item As teacher In arrTDpt1
                        Console.WriteLine(item)
                    Next
                    Exit Select

                Case 6
                    Console.WriteLine("------studentdepart2-------")
                    For Each item As student In arrSDpt2
                        Console.WriteLine(item)
                    Next
                    Console.WriteLine("------teacherdepart2-------")
                    For Each item As teacher In arrTDpt2
                        Console.WriteLine(item)
                    Next
                    Exit Select
                Case 7
                    Console.WriteLine("-----------before sort------------")
                    For Each item As student In arrSDpt1
                        Console.WriteLine(item)
                    Next
                    StuSortAge(arrSDpt1)

                    Console.WriteLine("-----------after sort------------")
                    For Each item As student In arrSDpt1
                        Console.WriteLine(item)
                    Next
                    Exit Select

                Case 8
                    Console.WriteLine("-----------before sort------------")
                    For Each item As student In arrSDpt1
                        Console.WriteLine(item)
                    Next
                    StuSortName(arrSDpt1)

                    Console.WriteLine("-----------after sort------------")
                    For Each item As student In arrSDpt1
                        Console.WriteLine(item)
                    Next
                    Exit Select
                Case 9
                    For Each item As student In arrSDpt1
                        MergeStudent1.Add(item)
                    Next
                    For Each item As student In arrSDpt2
                        MergeStudent1.Add(item)
                    Next
                    StuSortAge(MergeStudent1)


                    Using swStu As StreamWriter = New StreamWriter("MergeStudent1.txt")
                        For Each item As student In MergeStudent1
                            swStu.WriteLine(item)

                        Next
                    End Using

                    Exit Select

                Case 10
                    For Each item As student In arrSDpt1
                        MergeStudent2.Add(item)
                    Next
                    For Each item As student In arrSDpt2
                        MergeStudent2.Add(item)
                    Next
                    StuSortName(MergeStudent2)


                    Using swStu As StreamWriter = New StreamWriter("MergeStudent2.txt")
                        For Each item As student In MergeStudent2
                            swStu.WriteLine(item)

                        Next
                    End Using

                    Exit Select


                Case 11
                    Exit Select
                Case Else
                    Console.WriteLine("the option not supported")


            End Select





        Loop Until opt = 11


        Console.WriteLine("------studentdepart1-------")
        For Each item As student In arrSDpt1
            Console.WriteLine(item)
        Next
        Console.WriteLine("------studentdepart2-------")
        For Each item As student In arrSDpt2
            Console.WriteLine(item)
        Next
        Console.WriteLine("------teacherdepart1-------")
        For Each item As teacher In arrTDpt1
            Console.WriteLine(item)
        Next
        Console.WriteLine("------teacherdepart2-------")
        For Each item As teacher In arrTDpt2
            Console.WriteLine(item)
        Next
        Console.ReadLine()

    End Sub

End Module
