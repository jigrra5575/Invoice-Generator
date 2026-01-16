<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

<h2>🌟 Project Overview</h2>
This Invoice Management System is built using ASP.NET Core MVC, featuring full CRUD operations, product-wise dynamic calculations, invoice preview generation, and integrated online payment functionality.
The application provides a smooth workflow from creating an invoice → editing products → generating invoice → making payment → viewing animated success confirmation.
<h2>📦 Required NuGet Packages:</h2>
1.Microsoft.EntityFrameworkCore<br>
2.Microsoft.EntityFrameworkCore.SqlServer<br>
3.Microsoft.EntityFrameworkCore.Tools<br>
4.Microsoft.VisualStudio.Web.CodeGeneration.Design<br><br>

<img width="699" height="317" alt="packages" src="https://github.com/user-attachments/assets/1d6f3fa8-fb97-4a12-8196-1919b1f07237" />

<h2>📁 Project Structure: </h2>
InvoiceApplication/<br>
│── Controllers/<br>
│── Models/<br>
│── Views/<br>
│── Migrations/<br>
│── wwwroot/<br>
│── appsettings.json<br>
│── Program.cs<br>
│── Startup.cs<br><br>
<img width="284" height="400" alt="file layout" src="https://github.com/user-attachments/assets/e64cefee-805c-4996-9441-7c4734f8a04e" />
<h2> 🖼️ Screenshots:<h2>
🏠 1. Home Page<br><br>
<img width="1439" height="861" alt="home page" src="https://github.com/user-attachments/assets/c48aea37-629b-4ee9-8d57-d794f03b37db" /><br><br>
🧾 2. Create Invoice Page<br><br>
<img width="1425" height="772" alt="create page" src="https://github.com/user-attachments/assets/f627c458-f142-4dce-9323-57da098803f0" /><br><br>
✏️ 3. Edit Invoice Page (Auto-Filled)<br><br>
<img width="1424" height="818" alt="edit page" src="https://github.com/user-attachments/assets/b98b685e-04d9-4097-85a1-eaa21e5e3a07" /><br><br>
🛠️ 4. Product Edit Dialog<br>
[when you click on product edit button this diologue box open and you are edit that products all details which you want to edit]<br><br>
<img width="1379" height="734" alt="editprodutname" src="https://github.com/user-attachments/assets/9b9d3c06-fe31-4b9a-982a-59ca8770c926" /><br><br>
🗑️ 5. Invoice Delete Confirmation<br><br>
<img width="1435" height="851" alt="delete confirm page" src="https://github.com/user-attachments/assets/2ddd576c-8c20-4892-9fbc-2782d98a239b" /><br><br>
🧮 6. Invoice Generate Page (With Pay Now)<br><br>
<img width="1435" height="862" alt="invoice page" src="https://github.com/user-attachments/assets/3747bae4-03d2-48e5-b8b6-1027c3b84c53" /><br><br>
💳 7. Payment Page<br>You can pay direct to Dealer via using 'Pay Now' Button and its redirect to you to Payment page--<br><br>
<img width="1421" height="817" alt="payment page" src="https://github.com/user-attachments/assets/007f6434-f33a-4575-92e0-f164d5a027dd" /><br><br>
🎉 8. Successful Payment Animation Page<br><br>
<img width="1439" height="528" alt="succes payment page" src="https://github.com/user-attachments/assets/54f0b458-535c-4911-a76a-6e497bb395c3" />
<h2>✨ Features:</h2>
<ul>
<li>Create, edit, delete invoices</li>
<li>Add unlimited products</li>
<li>Edit product details using modal dialog</li>
<li>Auto-calculate totals</li>
<li>Generate invoice preview</li>
<li>Pay dealer via payment gateway</li>
<li>Animated success screen</li>
<li>Clean, responsive UI</li>
</ul>
<h2>🛠️ Tech Stack:</h2>
<br>
<table class="w-100">
  <tr>
    <th>Layer</th>
    <td>Technology</td>
  </tr>
  <tr>
    <th>Backend</th>
    <td>ASP.NET Core MVC</td>
  </tr>
  <tr>
    <th>ORM</th>
    <td>Entity Framework Core</td>
  </tr>
  <tr>
    <th>Database</th>
    <td>	SQL Server</td>
  </tr>
  <tr>
    <th>UI</th>
    <td>Bootstrap 5</td>
  </tr>
  <tr>
    <th>Frontend</th>
    <td> Interactions	jQuery & AJAX</td>
  </tr>
</table>

<h2>🚀 How to Run</h2>
1️⃣ Clone Repository<br>
git clone https://github.com/jigrra5575/Invoice-Generator.git <br><br>
2️⃣ Update Database Connection<br>
Edit appsettings.json<br><br>
3️⃣ Apply Migrations<br>
update-database<br><br>
4️⃣ Run Application<br>
dotnet run<br><br>
	

	

