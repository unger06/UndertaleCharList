# Project - Undertale Character List 
| Date | Chapter(s) | Description |
|--|--|--|
| 27.04.2023 | 1) | Created the file and added the chapter headings |
| 01.05.2023 | 1) <br>2) <br>2.1) <br>2.2) <br>2.3) <br>2.4) | - Added description/text to the chapters <br> - Added subheadings to the already existing 2 main headings |
| 07.05.2023 | 3)<br>2.3)-->3.2) <br>2.4)-->3.3) <br>3.1) <br>3.1.1) <br>3.2.1) <br>3.3.1)| - Moved some of the subheadings to different chapters <br>- Added a whole new Chapter ( **"3) How does the Software-Desing look?"** ) <br>- started adding pictures and describing the API  |
| 08.05.2023 |  |  |

## 1) What is "Undertale"?
"Undertale" is a RPG-like game where you play as a human who has fallen into a hole and woke up in an underground world full of monsters. 

As the main protagonist you have the power to either kill and destroy every living being in the underground, which rewards you with LV (it usually stands for LEVEL, but the main antagonist calls it "LOVE" to confuse the player) and G (short for GOLD / it is used as the currency of the game), or spare everyone, make friends with many different monsters and escape the underground together. 
> For more information visit the official Undertale Website [here](https://undertale.com/) (created by Toby Fox). 

## 2) What is this project about?
### 2.1) Description
Undertale has many different and unique characters. Doesn't matter if they are a main character, a NPC (Non Playable Character) or just a dog. This project collects and stores every single character along with their many abilities, features and attributes into a list, so the user can view them without the need to play the game. 

### 2.2) Functionality
The user should also be able to add, edit, delete and view different characters using a WPF application and a Website.
> **Note:** because of time problems and the underestimated project size the *Website* can *only display* the characters.

## 3) How does the Software-Design look?
### 3.1) Spring Boot API
<u>*Programming language:*</u> Java (Maven)
<u>*Operations:*</u> Manages Add / Edit / Delete / View Requests
<u>*Dependencies:*</u>

#### 3.1.1)  Functionality / Structure
The API acts like a connector between the application in the Frontend and the MongoDB database in the Backend. The application sends requests in the form of HTTP-Requests with the path (used for connecting to the different collections) and the request method (GET --> View / POST --> Add / PUT --> Edit / DELETE --> Delete) attached to it. 

**Project-Structure:**
![API-Project Structure](https://lh3.googleusercontent.com/9ukwAEFvpG7lGeo7m8iyiKWlwL_V8J9kQd_Qj2DQcDVo3Jge2-rA97rdHf8WNhyieDeHgIsdOv0bteJu3B56jxw195fDIDh7TzXImpmNvP2RFLWBfxK4aJCh9HJY6yb8CWfXos6gRTDvACFKCraiXOC-LO_lO0p2XwCBk_89ZLljugQg_7_RUS9ZaYCMmyqcqofnupgQx2En4nv-Fdn-yrSL6SXAo64Akwi6PF_2nrMTJrSRoc8yVTPIlN5YEul7oXFEDQdJ-eK4BtwM7NioC-uCpMYGML2gBWGCLDhW60GguDuiFsaIAviAKuRsizHJKlVpgMTlpLRl1VqOraca6R9BL1kxqlGLMJN8ZkmtwpzBKJWc0eRd7S88zzVbsqYoH5IurZo13GToi97aeg5-HE6SGu9AB2_bD2Msso_JmQlM8DY1WWCYPp6iOUZ4vBlq97pTS7RyPC2IdesGltAyEXAocNBETr89TD4ABAawo1g9HmjABLBFKGMue6OzofXVxUUiHFXAIe-kjfefC1sBrzv2uZBNANHLme5-wpXhGZ0NjI7hFDnhWzkqbifBv9Bd-jz7XZ5IMiUAxIgTm-nGG0WRa_ik4CQQMCUuegqj5FtVIIQ-iAUnP2u83kHm3nz5DjvayluqsoQlORBsJF72RT8NwHaGjbm9nwEPlfG1Vo3oj8xTIVcwIT-K_VSy3LR3NJ_kaYTKYA2L4UgxqnqDTQBqaO59UnYTy_Iv65HTqIN9LpCT8qSffJdKp_29zrw2OXZNy1-hfWQYig4gaBII9kRdM_LgHiaR3cWO4Ku1BcvwOFDKIy147r261xyyVA-vx0sDL3bevlxwCZ7lwVhwnkNq-uE2-F-_6K-3va4KswYeDjbEpPm7B7tXtxP_kgU6IVSq8RhQwruYFYw_LfaAy7JMO_vAj6HFTxj7hQW0K6-r=w411-h791-s-no?authuser=0 =200x)
This project has 3 different types of characters. Every single one has it's own Java Class, Controller, Repository and Service. In the *pom.xml* are all of the dependencies located the API needs to work correctly. The *application.properties* is used for changing the port of the API and also for specifying the MongoDB Atlas connection string.
> The "AllCharController" and "AllCharService" are working but aren't used in the WPF-application

**Main Character:**
**MainChar.cs:**
```java
@Document(collection = "mainCharacters")  
public class MainChar {  
  @MongoId  
  private String id;  
  private String name;  
  private List<String> appearances;  
  private String role;  
  private String status;  
  private int maxHealth;  
  private Map<String, Ability> abilities;  
  
  public MainChar() {  
  
 }
...
```
With the annotation *"@Document(collection = mainCharacter)"*, the API knows where the data of the document is stored. Every main character also gets the internal ID from MongoDB *("@MongoId")*. For every attribute exists a getter and setter below the Constructors. The Ability item, that is stored in the dictionary, is defined in the same class.
<br>
```java
...
public static class Ability {  
  private String name;  
  private List<String> features;  
  
  // GETTER AND SETTER
  public String getName() { return name; }  
  public void setName(String name) { this.name = name; }  
  public List<String> getFeatures() { return features; }  
  public void setFeatures(List<String> features) { this.features = features; }
}
...
```
Every Ability has a name and a list of features. This class exists inside MainChar.cs.
<br>
**MainCharRepo.cs:**
```java
@RepositoryRestResource(collectionResourceRel = "mainCharacters", path = "char/mainChar")  
public interface MainCharRepo extends MongoRepository<MainChar, String> {  
  List<MainChar> findByName(@Param("name") String name);  
}
```
All of the main characters get saved in this Repository. The collection *(where the items are stored in the database)* and path *(the same as in the Controller)* need to be specified. Instead of "findById()" I changed it so the API finds the item by the name.
<br>
 **MainCharService.cs:**
```java
@Service  
public class MainCharService {  
  @Autowired  
  private MainCharRepo mainCharRepo;  
  
  public List<MainChar> getAllMainChars() {  
    System.out.println(this.mainCharRepo.findAll());  
    return (List<MainChar>) this.mainCharRepo.findAll();  
  }  
  public List<MainChar> getMainChar(String name) { 
    return this.mainCharRepo.findByName(name); 
  }  
  
  public void addMainChar(MainChar mainChar) {  
    this.mainCharRepo.save(mainChar);  
  }  
  public void updateMainChar(String id, MainChar mainChar) {  
    this.mainCharRepo.save(mainChar);  
  }  
  public void deleteMainChar(String id) {  
    this.mainCharRepo.deleteById(id);  
  }
}
```
The "@Service"-Annotation is used for identifying what class should be used as the Service. This service passes the different actions on to the repository, which then carries out the actions using the integrated *MongoRepository* class. 
<br>
**MainCharController.cs:**
```java
@RestController  
@RequestMapping("/char/mainChar")  
public class MainCharController {  
  @RequestMapping("/home")  
  public String serviceTest() { return "Das Service funktioniert!"; }
  
  @Autowired  
  private MainCharService mainCharService;  
  
  // VIEW
  @GetMapping("")  
  public List<MainChar> getAllMainChars() {  
    return mainCharService.getAllMainChars();  
  }
    
  // VIEW A SPECIFIC CHARACTER  
  @GetMapping("/{name}")  
  public List<MainChar> getMainChar(@PathVariable String name) { 
    return mainCharService.getMainChar(name); 
  }  
  
  // ADD 
  @PostMapping("")  
  public String addMainChar(@RequestBody MainChar mainChar) {  
    mainCharService.addMainChar(mainChar);  
    String response = "{\"success\": true, \"message\": Main Character has been added successfully.}";  
    return response;  
  }
    
  // UPDATE  
  @PutMapping("/{id}")  
  public String updateMainChar(@RequestBody MainChar mainChar, @PathVariable String id) {  
    mainCharService.updateMainChar(id, mainChar);  
    String response = "{\"success\": true, \"message\": Main Character has been updated successfully.}";  
    return response;  
  }  
  
  // DELETE
  @DeleteMapping("/{id}")  
  public String deleteMainChar(@PathVariable String id) {  
    mainCharService.deleteMainChar(id);  
    String response = "{\"success\": true, \"message\": Main Character has been deleted successfully.}";  
    return response;  
  }
}
```
The "@RestController"-Annotation is used for identifying what class should be used as the Controller. If the "@RequestMapping"-annotation is used for the entire class, the API only accepts requests for this Controller if the path is *"localhost:< port >/char/mainChar ..."*. Every other path required for viewing, editing, deleting and adding, specified in the different "@...Mapping(" ")"-annotations are getting added to the current path and are not a stand-alone path. If the user wants to get a specific item with the name *"Hugo"* the HTTP-Request path should look something like this: **localhost:8080/char/mainChar/Hugo**
<br>

**NPC:**
**Npc.cs:**
```java
@Document(collection = "npc")  
public class Npc {  
  @MongoId  
  private String id;  
  private String name;  
  private List<String> appearances;  
  private String role;  
  private String status;  
  private int maxHealth;  
  private int attack;  
  private int defense;  
  
  public Npc() {  
  }
...
```
With the annotation *"@Document(collection = "npc")"*, the API knows where the data of the document is stored. Every NPC also gets the internal ID from MongoDB *("@MongoId")*. For every attribute exists a getter and setter below the Constructors.
<br>

**Vendor:**
**Vendor.cs:**
```java
@Document(collection = "vendors")  
public class Vendor {  
  @MongoId  
  private String id;  
  private String name;  
  private List<String> appearances;  
  private String role;  
  private String status;  
  private List<String> wares;  
  private Map<String, Feature> features;  
  
  public Vendor() {  
  }
...
```
With the annotation *"@Document(collection = "vendors")"*, the API knows where the data of the document is stored. Every vendor also gets the internal ID from MongoDB *("@MongoId")*. For every attribute exists a getter and setter below the Constructors.

> This project uses 3 different character types. 
> The only things getting changed for the other classes are the attributes of the items and also the names of the Controller, Service and Repositories. Also the HTTP-request paths get changed from *".../char/mainChar"* to *".../char/npc"* and *".../char/vendor"*

### 3.2) WPF application:
<u>*Programming language:*</u> C#
<u>*Operations:*</u> Add / Edit **(not working)** / Delete / View

#### 3.2.1) Functionality 
<u>*Main Window:*</u> When the application starts, the main window pops up. There, the user can choose which characters should be viewed (Main Characters / NPCs / Vendors / all three). If the user chooses any specific type of character they can also add a new one, using the different controls provided by the application below the list. Every single character in the list also has it's own delete-button, where the corresponding item completely gets deleted from the list in the application but also from the MongoDB database in the backend. 

<u>*Edit Window:*</u> If the user clicks on any item in the list twice, a new window opens. The new window is the "Edit Window" where the user can either just look at every single attribute of the character or edit different things. After they click on the SAVE-button the original values of the different attributes get overwritten by the modified values. But if the user closes the window by clicking on the X-icon in the top right corner or clicks on the RESET-button, nothing should change in the database and all of the controls should be reset to their default values.
> ~~If the option that every type of character gets shown is selected, the user **cannot add any new characters** to the list. They can still **modify and delete** existing ones though.~~
> Not sure if the "View all Character Option" gets added to the final application


### 3.2.2) Code Review

### 3.3) Website
<u>*Programming Language(s):*</u> React(?); HTML; CSS; JavaScript
<u>*Operations:*</u> View

#### 3.3.1) Functionality
After the server is started (locally) the user should be able to access the Website via "http://localhost:8080". It should automatically route to the "Home" of the website where every single character can be seen. There the user can also filter through the list using the provided controls at the top. 
If they click on any character, "Home" should be replaced by the character's name in the path. The website should then automatically reroute to a new HTML-file, where every single attribute of the selected character gets displayed.

## 
 

> Written with [StackEdit](https://stackedit.io/).
