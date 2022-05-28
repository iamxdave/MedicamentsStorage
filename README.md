# MedicamentsStorage
Medicament management through <b>dotnet REST API</b> by <b>EntityFrameworkCore</b> using <b>CodeFirst</b> approach.<br>
<br>
<b>The application meets the assumptions of SOLID and DI</b>

<hr>

## How does it work

  Application creates a database for a company to facilitate its management in a much simpler an cleaner way.
  The database created by API i shown bellow and fulfilled with example data:
<p align="center">
  <img src=https://user-images.githubusercontent.com/74014874/170826979-82f64495-ac23-4538-954f-e6ac9651c2f2.png
   >
</p>

<hr>

  <h3>API allows you to maintain certain operation that allow the user to get, put, post and delete data in the database e.g:</h3>
<ol>
  <li><h4> Return a Doctor by responding to the</h4>
    <p align="center">
      <b>HTTP GET request to /api/doctors/{id}</b>
    </p>
  </li>
  <br>
  <li><h4>Put a client's data by responding to the</h4>
    <p align="center">
      <b>HTTP PUT request to /api/doctors</b>
    </p> 
          API asks for doctor's ID and specific columns fulfilled with values to change.
   </li>
   <br>
  <li><h4> Add a doctor by responding to the</h4> 
    <p align="center">
      <b>HTTP POST request to /api/doctors</b>
    </p>
          API asks for doctor's data and automatically generates an id key in the database.
  </li>
  <li><h4>Delete a client's data by responding to the</h4>
    <p align="center">
      <b>HTTP DELETE request to /api/doctors/{id}</b>
    </p> 
   </li>
   <br>
 </ol>
 <br>
  
<hr>
  
  ## API requires a JWT authentication token to be able to access the database
  <br>
  
  **Application allows you to obtain a token by logging in and stores sensitive data in accordance with SALT and PBKDF2.**
  
  </br>
  <ol>
    <li>Allows to gather "user" role to gain management ability in the database</li>
    <li>Allows to get a JWT token and refresh token for changing JWT token after it disappears over time.</li>
    <li>Registers a new user in the database.</li>
    <li>Checks if a user's password is correct.</li>
    <li>Saves all exceptions to the log file by own middleware.</li>
  </ol>


  **API is connected to my database by default and to set up yours you need to change ConnectionString in the file appsettings.json**

<hr>
