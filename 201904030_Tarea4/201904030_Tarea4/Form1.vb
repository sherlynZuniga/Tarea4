Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        'Colocando datos en listbox'
        If (fila <= 11) Then
            'a continuación se verifica que se haya ingresado un dato como nombre'
            If (TextBox1.Text <> "") Then
                nombre(fila) = TextBox1.Text
            Else
                MsgBox("Error, no ingresó nombre")
                TextBox1.Focus() : Exit Sub
            End If

            ListBox1.Items.Add(nombre(fila))




            'a continuación se verifica que se haya ingresado un dato en NIT
            If (TextBox2.Text > "") Then
                NIT(fila) = TextBox2.Text
            Else
                MsgBox("Error, no ingresó NIT")
                TextBox1.Focus() : Exit Sub
            End If

            ListBox2.Items.Add(NIT(fila))

            'a continuación se verifica que se haya ingresado un dato saldo anterior'
            If (TextBox3.Text > "") Then
                saldoant(fila) = TextBox3.Text
            Else
                MsgBox("Error, no ingresó Saldo anterior")
                TextBox1.Focus() : Exit Sub
            End If


            'a continuación se procede a verificar que se haya ingresado un dato correcto para el consumo'
            If (IsNumeric(TextBox4.Text) And Val(TextBox4.Text) > 0) Then
                'en la siguiente instrucción se usa la Función VAL para convertir de string a valor numérico, ya que el 
                'vector sueldo es de tipo numérico
                consumo(fila) = Val(TextBox4.Text)
            Else
                MsgBox("Error, dato no válido")
                TextBox4.Focus() : Exit Sub
            End If
        End If

        'calculo saldo anterior'
        If saldoant(fila) < 0 Then
            saldonuevo(fila) = saldoant(fila)
        ElseIf saldoant(fila) > 0 Then
            saldonuevo(fila) = saldoant(fila) + (saldoant(fila) * 2 / 100)
        End If
        ListBox5.Items.Add(saldonuevo(fila))


        'calculo pago inicial'
        Select Case ComboBox1.SelectedIndex
            Case 0
                Select Case Val(TextBox4.Text)
                    Case 1 To 100
                        pagoinicial(fila) = consumo(fila) * 0.99
                    Case 101 To 300
                        pagoinicial(fila) = consumo(fila) * 1.2
                    Case Is >= 301
                        pagoinicial(fila) = consumo(fila) * 3
                End Select
            Case 1
                Select Case Val(TextBox4.Text)
                    Case 1 To 100
                        pagoinicial(fila) = consumo(fila) * 1.99
                    Case 101 To 300
                        pagoinicial(fila) = consumo(fila) * 2.2
                    Case Is >= 301
                        pagoinicial(fila) = consumo(fila) * 4
                End Select
        End Select

        ListBox3.Items.Add(pagoinicial(fila))


        'calculo de descuento'
        Select Case ComboBox2.SelectedIndex
            Case 0
                descuento(fila) = Val(pagoinicial(fila) * 20 / 100)

            Case 1
                descuento(fila) = Val(pagoinicial(fila) * 10 / 100)
        End Select

        ListBox4.Items.Add(descuento(fila))

        'calculo total'
        total(fila) = Val(pagoinicial(fila)) + Val(saldonuevo(fila)) - Val(descuento(fila))

        ListBox6.Items.Add(total(fila))



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()

    End Sub
End Class
