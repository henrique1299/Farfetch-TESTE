# Farfetch-TESTE
Farfetch - TESTE - .NET Software Engineer Intern

# Installation

## Using your own website page:
1. In the `ItensController.cs` change the database info in the `connect()` method.
2. In `appsettings` change the ConnectionStrings.
3. In `wwwroot`, add your website files.
4. Use the `edit-{field}` id for the edit form inputs and `add-{field}` for the add form.
5. Add the following table to display the itens:  
```
<table class="table">
   <tr>
       <th>Itens</th>
          <th></th>
          <th></th>
   </tr>
   <tbody id="itens"></tbody>
</table>
  ```
5. Add the scripts (site.js is already on the js folder of wwwroot):
```
 <script src="js/site.js" asp-append-version="true"></script>
 <script type="text/javascript">
        getItens();
 </script>
```
6. Your form should look like this:
```
<form action="javascript:void(0);" method="POST" onsubmit="addItem()">
    <input type="text" id="add-name">
    ...
    <input type="submit" value="Add">
</form>
```
7. Delete the not used functions on `js/site.js`

## Using the default API web page

1. Rename the `index.html`.
2. Add your website files to `wwroot`.
3. Add a link to the renamed `index.html` page on your website.
4. In the `ItensController.cs`, change the database info in the `connect()` method.
5. In `appsettings` change the ConnectionStrings.
