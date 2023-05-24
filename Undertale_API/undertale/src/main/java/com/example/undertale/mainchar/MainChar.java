package com.example.undertale.mainchar;

import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import org.bson.types.ObjectId;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.data.mongodb.core.mapping.MongoId;

import java.util.List;

/*@Document(collection = "characters")
public class MainChar {
    @Id
    //@GeneratedValue(strategy= GenerationType.AUTO)
    private Integer id;
    private String name;
    private ArrayList<String> appearances;
    private String role;          //Extra wishes (no Onions / extra pickles)
    private String status;
    private Integer maxHealth;
    private ArrayList<ArrayList<String>> abilities;

    public MainChar() {
    }

    public MainChar(Integer id, String name, ArrayList<String> appearances, String role, String status, Integer maxHealth, ArrayList<ArrayList<String>> abilities) {
        super();
        this.id = id;
        this.name = name;
        this.appearances = appearances;
        this.role = role;
        this.status = status;
        this.maxHealth = maxHealth;
        this.abilities = abilities;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() { return name; }

    public void setName(String name) { this.name = name; }

    public ArrayList<String> getAppearances() { return appearances; }

    public void setAppearances(ArrayList<String> appearances) { this.appearances = appearances; }

    public String getRole() { return role; }

    public void setRole(String role) { this.role = role; }

    public String getStatus() { return status; }

    public void setStatus(String status) { this.status = status; }

    public Integer getMaxHealth() { return maxHealth; }

    public void setMaxHealth(Integer maxHealth) { this.maxHealth = maxHealth; }

    public ArrayList<ArrayList<String>> getAbilities() { return abilities; }

    public void setAbilities(ArrayList<ArrayList<String>> abilities) { this.abilities = abilities; }
}*/
/*
@Document(collection = "mainCharacters")
public class MainChar {
    @Id
    @GeneratedValue(strategy= GenerationType.AUTO)
    private String id;
    private String name;
    private String role;
    private String status;
    private Integer maxHealth;

    public MainChar() {
    }

    public MainChar(String id, String name, String role, String status, Integer maxHealth) {
        super();
        this.id = id;
        this.name = name;
        this.role = role;
        this.status = status;
        this.maxHealth = maxHealth;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() { return name; }

    public void setName(String name) { this.name = name; }

    public String getRole() { return role; }

    public void setRole(String role) { this.role = role; }

    public String getStatus() { return status; }

    public void setStatus(String status) { this.status = status; }

    public Integer getMaxHealth() { return maxHealth; }

    public void setMaxHealth(Integer maxHealth) { this.maxHealth = maxHealth; }
}
*/
import java.util.Map;

//@JsonDeserialize(using = NullToDefaultDeserializer.class)   // BELONGS TO THE DESERIALIZER
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

    public MainChar(String name, List<String> appearances, String role, String status, int maxHealth, Map<String, Ability> abilities) {
        super();
        this.name = name;
        this.appearances = appearances;
        this.role = role;
        this.status = status;
        this.maxHealth = maxHealth;
        this.abilities = abilities;
    }

    public String getId() { return id; }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<String> getAppearances() {
        return appearances;
    }

    public void setAppearances(List<String> appearances) {
        this.appearances = appearances;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public int getMaxHealth() {
        return maxHealth;
    }

    public void setMaxHealth(int maxHealth) {
        this.maxHealth = maxHealth;
    }

    public Map<String, Ability> getAbilities() {
        return abilities;
    }

    public void setAbilities(Map<String, Ability> abilities) {
        this.abilities = abilities;
    }

    public static class Ability {
        private String name;
        private List<String> features;

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public List<String> getFeatures() {
            return features;
        }

        public void setFeatures(List<String> features) {
            this.features = features;
        }
    }
}
