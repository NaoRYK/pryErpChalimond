$conn = New-Object -ComObject ADODB.Connection
$conn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\Users\Alumno\source\repos\pryErpChalimond\pryErpChalimond\bin\Debug\Chalimond.accdb;")
$rs = $conn.OpenSchema(4) # adSchemaColumns
while (-not $rs.EOF) {
    if ($rs.Fields.Item("TABLE_NAME").Value -eq "Usuarios") {
        Write-Output ($rs.Fields.Item("COLUMN_NAME").Value + " - " + $rs.Fields.Item("DATA_TYPE").Value)
    }
    $rs.MoveNext()
}
$conn.Close()
