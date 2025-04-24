# Recipe API

This is a .NET 9 Web API project that manages Recipes and Ingredients. It was developed as a pre-project for the LACUNA Software DevOps course. Below you will find instructions on how to set up, run, and test the API.

--------------------------------------------------------------------------------

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet)  
  Confirm installation by running:
  ```
  dotnet --version
  ```
  You should see a version that starts with 9.x.x.

### Steps to Run the Project

1. **Clone or Download the Project**  
   If you obtained this repository in a zipped format, unzip it into a folder of your choice. Otherwise, if you're cloning from a Git repository, run in your terminal:
   ```
   git clone <repo-url>
   ```
   Then,
   ```
   cd Recipe_API
   ```

2. **Restore Dependencies**  
   Restore all NuGet packages by running:
   ```
   dotnet restore
   ```

3. **Build the Project**  
   Compile the project to ensure everything is in order:
   ```
   dotnet build
   ```

4. **Run the Web API**  
   Run it with:
   ```
   dotnet run
   ```
   By default, it will start listening at something like:
   ```
   http://localhost:5000 or https://localhost:7000
   ```
   (The exact port may vary.)

--------------------------------------------------------------------------------

## Using the API

Below you will find example endpoints (typical REST patterns) for both Recipes and Ingredients.

If you are using a tool like [Postman](https://www.postman.com/) or [curl](https://curl.se/), these sample requests can be used to interact with the API.

### Recipes Endpoints

1. **Get All Recipes**  
   • Endpoint: `GET /api/recipes`  
   • Description: Returns a list of all recipes.

   Example with curl:
   ```
   curl -X GET "http://localhost:<PORT>/api/recipes"
   ```

2. **Get a Specific Recipe by ID**  
   • Endpoint: `GET /api/recipes/{id}`  
   • Description: Returns a single recipe by its ID.

   Example with curl:
   ```
   curl -X GET "http://localhost:<PORT>/api/recipes/1"
   ```
   (Here, replace `1` with the desired recipe ID.)

3. **Create a New Recipe**  
   • Endpoint: `POST /api/recipes`  
   • Description: Creates a new recipe.  
   • Body (JSON):
     ```
     {
       "name": "Example Recipe",
       "preparationMethod": "Steps for making the recipe...",
       "ingredients": [
         {
           "ingredientId": 1,
           "quantity": 100
         }
       ]
     }
     ```
   Example with curl:
   ```
   curl -X POST "http://localhost:<PORT>/api/recipes" \
        -H "Content-Type: application/json" \
        -d "{
              \"name\": \"Example Recipe\",
              \"preparationMethod\": \"Steps for making the recipe...\",
              \"ingredients\": [
                {
                  \"ingredientId\": 1,
                  \"quantity\": 100
                }
              ]
            }"
   ```

4. **Update an Existing Recipe**  
   • Endpoint: `PUT /api/recipes/{id}`  
   • Description: Updates an existing recipe.  
   • Body (JSON):
     ```
     {
       "id": 1,
       "name": "Updated Recipe Name",
       "preparationMethod": "Updated steps...",
       "ingredients": [
         {
           "ingredientId": 2,
           "quantity": 50
         }
       ]
     }
     ```
   Example with curl:
   ```
   curl -X PUT "http://localhost:<PORT>/api/recipes/1" \
        -H "Content-Type: application/json" \
        -d "{
              \"id\": 1,
              \"name\": \"Updated Recipe Name\",
              \"preparationMethod\": \"Updated steps...\",
              \"ingredients\": [
                {
                  \"ingredientId\": 2,
                  \"quantity\": 50
                }
              ]
            }"
   ```

5. **Delete a Recipe**  
   • Endpoint: `DELETE /api/recipes/{id}`  
   • Description: Deletes the recipe with the specified ID.

   Example with curl:
   ```
   curl -X DELETE "http://localhost:<PORT>/api/recipes/1"
   ```

--------------------------------------------------------------------------------

### Ingredients Endpoints

1. **Get All Ingredients**  
   • Endpoint: `GET /api/ingredients`  
   • Description: Returns a list of all ingredients.

   Example with curl:
   ```
   curl -X GET "http://localhost:<PORT>/api/ingredients"
   ```

2. **Get a Specific Ingredient by ID**  
   • Endpoint: `GET /api/ingredients/{id}`  
   • Description: Returns an ingredient by its ID.

   Example with curl:
   ```
   curl -X GET "http://localhost:<PORT>/api/ingredients/2"
   ```

3. **Create a New Ingredient**  
   • Endpoint: `POST /api/ingredients`  
   • Description: Creates a new ingredient.  
   • Body (JSON):
     ```json
     {
       "name": "New Ingredient",
       "unitOfMeasure": "grams"
     }
     ```
   Example with curl:
   ```bash
   curl -X POST "http://localhost:<PORT>/api/ingredients" \
        -H "Content-Type: application/json" \
        -d "{
              \"name\": \"New Ingredient\",
              \"unitOfMeasure\": \"grams\"
            }"
   ```

4. **Update an Existing Ingredient**  
   • Endpoint: `PUT /api/ingredients/{id}`  
   • Description: Updates an existing ingredient.  
   • Body (JSON):
     ```json
     {
       "id": 2,
       "name": "Updated Ingredient Name",
       "unitOfMeasure": "ml"
     }
     ```
   Example with curl:
   ```bash
   curl -X PUT "http://localhost:<PORT>/api/ingredients/2" \
        -H "Content-Type: application/json" \
        -d "{
              \"id\": 2,
              \"name\": \"Updated Ingredient Name\",
              \"unitOfMeasure\": \"ml\"
            }"
   ```

5. **Delete an Ingredient**  
   • Endpoint: `DELETE /api/ingredients/{id}`  
   • Description: Deletes the ingredient with the specified ID.

   Example with curl:
   ```
   curl -X DELETE "http://localhost:<PORT>/api/ingredients/2"
   ```

--------------------------------------------------------------------------------

## Notes

• Replace `<PORT>` with the actual port on which your application is running. By default, this is `5000` for HTTP or `7000` for HTTPS, unless otherwise configured in the `launchSettings.json` file. 
• The "id" fields in these JSON examples may or may not be required by your particular implementation. Depending on how your controllers are set up, the API might ignore the ID in the body and only use the one in the route.  

--------------------------------------------------------------------------------

## Contributing

Feel free to open issues or pull requests if you find any problems or have improvements.

--------------------------------------------------------------------------------
