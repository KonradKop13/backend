# Multimedia SOAP API Test Script
# This script tests all main SOAP endpoints for Movie, Book, and Game entities.
# Each request prints the response or error for easier debugging.

function Invoke-SoapRequest {
    param(
        [string]$Action,
        [string]$BodyXml,
        [string]$Description
    )
    Write-Host "\n==== $Description ====" -ForegroundColor Cyan
    try {
        $response = Invoke-WebRequest -Uri "http://localhost:5158/soap/multimedia" -Method POST -ContentType "text/xml; charset=utf-8" -Headers @{"SOAPAction" = $Action} -Body $BodyXml -ErrorAction Stop
        Write-Host $response.Content -ForegroundColor Green
    } catch {
        Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
        if ($_.Exception.Response -and $_.Exception.Response.Content) {
            Write-Host $_.Exception.Response.Content -ForegroundColor Yellow
        }
    }
}

# Test AddMovie
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/AddMovie" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <AddMovie xmlns="http://tempuri.org/">
      <movie>
        <Title>Test Movie</Title>
        <Director>Test Director</Director>
        <Year>2025</Year>
      </movie>
    </AddMovie>
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "AddMovie (add a new movie)"

# Test GetAllMovies
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/GetAllMovies" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetAllMovies xmlns="http://tempuri.org/" />
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "GetAllMovies (list all movies)"

# Test AddBook
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/AddBook" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <AddBook xmlns="http://tempuri.org/">
      <book>
        <Title>Test Book</Title>
        <Author>Test Author</Author>
        <Year>2025</Year>
      </book>
    </AddBook>
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "AddBook (add a new book)"

# Test GetAllBooks
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/GetAllBooks" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetAllBooks xmlns="http://tempuri.org/" />
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "GetAllBooks (list all books)"

# Test AddGame
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/AddGame" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <AddGame xmlns="http://tempuri.org/">
      <game>
        <Title>Test Game</Title>
        <Developer>Test Dev</Developer>
        <Year>2025</Year>
      </game>
    </AddGame>
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "AddGame (add a new game)"

# Test GetAllGames
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/GetAllGames" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetAllGames xmlns="http://tempuri.org/" />
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "GetAllGames (list all games)"

# Test DeleteMovie (delete movie with ID 1)
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/DeleteMovie" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <DeleteMovie xmlns="http://tempuri.org/">
      <id>1</id>
    </DeleteMovie>
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "DeleteMovie (delete movie with ID 1)"

# Test UpdateMovie (update movie with ID 2)
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/UpdateMovie" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <UpdateMovie xmlns="http://tempuri.org/">
      <movie>
        <Id>2</Id>
        <Title>Updated Movie Title</Title>
        <Director>Updated Director</Director>
        <Year>2025</Year>
      </movie>
    </UpdateMovie>
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "UpdateMovie (update movie with ID 2)"

# Test DeleteBook (delete book with ID 1)
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/DeleteBook" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <DeleteBook xmlns="http://tempuri.org/">
      <id>1</id>
    </DeleteBook>
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "DeleteBook (delete book with ID 1)"

# Test UpdateBook (update book with ID 2)
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/UpdateBook" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <UpdateBook xmlns="http://tempuri.org/">
      <book>
        <Id>2</Id>
        <Title>Updated Book Title</Title>
        <Author>Updated Author</Author>
        <Year>2025</Year>
      </book>
    </UpdateBook>
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "UpdateBook (update book with ID 2)"

# Test DeleteGame (delete game with ID 1)
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/DeleteGame" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <DeleteGame xmlns="http://tempuri.org/">
      <id>1</id>
    </DeleteGame>
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "DeleteGame (delete game with ID 1)"

# Test UpdateGame (update game with ID 2)
Invoke-SoapRequest `
    -Action "http://tempuri.org/IMultimediaSoapService/UpdateGame" `
    -BodyXml @'
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <UpdateGame xmlns="http://tempuri.org/">
      <game>
        <Id>2</Id>
        <Title>Updated Game Title</Title>
        <Developer>Updated Dev</Developer>
        <Year>2025</Year>
      </game>
    </UpdateGame>
  </soap:Body>
</soap:Envelope>
'@ `
    -Description "UpdateGame (update game with ID 2)"

Write-Host "\n==== All SOAP endpoint tests completed. ====" -ForegroundColor Cyan
