package com.example.undertale.npc;

import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.data.mongodb.core.mapping.MongoId;

import java.util.List;

//@JsonDeserialize(using = NullToDefaultDeserializer.class)   // BELONGS TO THE DESERIALIZER
@Document(collection = "npc")
public class Npc {
    @MongoId
    private String id;
    private String name;
    private List<String> appearances;
    private String role;
    private String status;

    public Npc() {
    }

    public Npc(String name, List<String> appearances, String role, String status) {
        super();
        this.name = name;
        this.appearances = appearances;
        this.role = role;
        this.status = status;
    }
    // getter and setter methods for each field

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
}
