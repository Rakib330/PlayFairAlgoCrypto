Console.Write("Enter the Plain Text:");
string PlainText = Console.ReadLine().ToUpper();

Console.Write("Enter the Key Text:");
string KeyText = Console.ReadLine().ToUpper();

Console.Write("I or J:");
string IorJ = Console.ReadLine().ToUpper();
Console.WriteLine();
Console.WriteLine("1 and 4. Removed spaces"); 
PlainText = PlainText.Replace(" ", "");
KeyText = KeyText.Replace(" ", "");
Console.WriteLine("PlainText = " + PlainText); 
Console.WriteLine("KeyText = " + KeyText);
Console.WriteLine();
string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";


Console.WriteLine("2.check Duplicat letters searially in plain text");
for (int i = 0; i < PlainText.Length - 1; i++)
{
    if (PlainText[i] == PlainText[i + 1])
    {
        PlainText = PlainText.Insert(i + 1, "X");
        i++;
    }
}
Console.WriteLine("PlainText = " + PlainText);
Console.WriteLine();
Console.WriteLine("7. I or J check in Key");
if (IorJ == "I")
{
    PlainText = PlainText.Replace('J', 'I');
    KeyText = KeyText.Replace('J', 'I');
    alphabet = alphabet.Replace('J', 'I');
}
else
{
    PlainText = PlainText.Replace('I', 'J');
    KeyText = KeyText.Replace('I', 'J');
    alphabet = alphabet.Replace('I', 'J');
}
Console.WriteLine("KeyText = " + KeyText);
Console.WriteLine();


Console.WriteLine("3. check PlainText is even length");
if (PlainText.Length % 2 == 1)
{
    PlainText = PlainText + "X";
}
Console.WriteLine("PlainText = " + PlainText); 
Console.WriteLine();

Console.WriteLine("5. Remove duplicate letters from Key");
for (int i = 0; i < KeyText.Length - 1; i++)
{
    for (int j = i + 1; j < KeyText.Length; j++)
    {
        if (KeyText[i] == KeyText[j])
        {
            KeyText = KeyText.Remove( j , 1 );
            j--;
        }
    }
}
Console.WriteLine("KeyText = " + KeyText);

Console.WriteLine();

Console.WriteLine("25 characters from the alphabet: "+alphabet);
for (int i = 0; i < KeyText.Length; i++)
{
    for (int j = 0; j < alphabet.Length; j++)
    {
        if (KeyText[i] == alphabet[j])
        {
            alphabet = alphabet.Remove(j, 1);
            j--; 
        }
    }
}
Console.WriteLine("remaining characters from the alphabet: " + alphabet);

Console.WriteLine();

char[,] matrix = new char[5, 5];
int index = 0;
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        if (index < KeyText.Length)
        {
            matrix[i, j] = KeyText[index];
            index++;
        }
        else
        {
            matrix[i, j] = alphabet[0];
            alphabet = alphabet.Remove(0, 1);
        }
    }
}


Console.WriteLine("6. Create a 5x5 matrix with values:");
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}

//9. Encrypt the Plain Text using the matrix
string cipherText = string.Empty;
for (int i = 0; i < PlainText.Length; i += 2)
{
    char firstChar = PlainText[i];
    char secondChar = PlainText[i + 1];
    int firstRow = -1, firstCol = -1;
    int secondRow = -1, secondCol = -1;
    // Find the position of the characters in the matrix
    for (int row = 0; row < 5; row++)
    {
        for (int col = 0; col < 5; col++)
        {
            if (matrix[row, col] == firstChar)
            {
                firstRow = row;
                firstCol = col;
            }
            if (matrix[row, col] == secondChar)
            {
                secondRow = row;
                secondCol = col;
            }
        }
    }
    // Encrypt based on their positions
    if (firstRow == secondRow) // Same row
    {
        cipherText += matrix[firstRow, (firstCol + 1) % 5];
        cipherText += matrix[secondRow, (secondCol + 1) % 5];
    }
    else if (firstCol == secondCol) // Same column
    {
        cipherText += matrix[(firstRow + 1) % 5, firstCol];
        cipherText += matrix[(secondRow + 1) % 5, secondCol];
    }
    else // Rectangle case
    {
        cipherText += matrix[firstRow, secondCol];
        cipherText += matrix[secondRow, firstCol];
    }
}

Console.WriteLine("8. Cipher Text: " + cipherText);

//decrypt the cipher text to verify
string decryptedText = string.Empty;
for (int i = 0; i < cipherText.Length; i += 2)
{
    char firstChar = cipherText[i];
    char secondChar = cipherText[i + 1];
    int firstRow = -1, firstCol = -1;
    int secondRow = -1, secondCol = -1;
    // Find the position of the characters in the matrix
    for (int row = 0; row < 5; row++)
    {
        for (int col = 0; col < 5; col++)
        {
            if (matrix[row, col] == firstChar)
            {
                firstRow = row;
                firstCol = col;
            }
            if (matrix[row, col] == secondChar)
            {
                secondRow = row;
                secondCol = col;
            }
        }
    }
    // Decrypt based on their positions
    if (firstRow == secondRow) // Same row
    {
        decryptedText += matrix[firstRow, (firstCol + 4) % 5];
        decryptedText += matrix[secondRow, (secondCol + 4) % 5];
    }
    else if (firstCol == secondCol) // Same column
    {
        decryptedText += matrix[(firstRow + 4) % 5, firstCol];
        decryptedText += matrix[(secondRow + 4) % 5, secondCol];
    }
    else // Rectangle case
    {
        decryptedText += matrix[firstRow, secondCol];
        decryptedText += matrix[secondRow, firstCol];
    }
}

Console.WriteLine("Decrypted Text: " + decryptedText);

//Console.WriteLine();
//Console.WriteLine("Plain Text: "+ PlainText);
//Console.WriteLine("Key Text: "+ KeyText);
//Console.WriteLine("Key Text: "+ alphabet);
