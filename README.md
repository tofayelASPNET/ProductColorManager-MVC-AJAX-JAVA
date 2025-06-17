🛍️ Product Management System – ASP.NET MVC (Code First + AJAX)
This is a Single Page Web Application (SPA) developed using ASP.NET MVC with Entity Framework Code First approach. The system is designed to manage Products, their associated Colors, and a join entity called Details. It supports full CRUD operations with AJAX and JavaScript for a smooth user experience.

✅ Key Features
🔧 ASP.NET MVC with Code First Migrations

📦 Manage Products and assign Colors dynamically

🔄 Many-to-Many relationship handled via Details entity

⚡ AJAX-based CRUD for fast interaction without full page reloads

🖼️ Product image handling and availability status tracking

📅 Product release date tracking
✅ Navigation properties allow for smooth data binding and EF relationships.

📦 Entity Relationships
One Product → Many Details

One Color → Many Details

Details = Bridge Table (Many-to-Many)
| Technology        | Purpose                   |
| ----------------- | ------------------------- |
| ASP.NET MVC       | Web framework             |
| Entity Framework  | ORM (Code First)          |
| JavaScript / AJAX | Client-side interactivity |
| Razor View        | Frontend rendering        |
| Bootstrap (opt.)  | Styling (if used)         |
📄 Example Use Case
Admin adds new Products with availability and release date.

Colors are predefined and mapped to products via the Details table.

AJAX calls fetch product-color mapping without reloading the page.

Updates or deletes reflect in real time on the same page.
