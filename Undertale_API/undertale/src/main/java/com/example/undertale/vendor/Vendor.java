package com.example.undertale.vendor;

import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.data.mongodb.core.mapping.MongoId;

import java.util.List;
import java.util.Map;

//@JsonDeserialize(using = NullToDefaultDeserializer.class)   // BELONGS TO THE DESERIALIZER
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

    public Vendor(String name, List<String> appearances, String role, String status, List<String> wares, Map<String, Feature> features) {
        super();
        this.name = name;
        this.appearances = appearances;
        this.role = role;
        this.status = status;
        this.wares = wares;
        this.features = features;
    }

    //Getter and Setter (Vendor)
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

    public String getRole() { return role; }

    public void setRole(String role) { this.role = role; }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public List<String> getWares() {
        return wares;
    }

    public void setWares(List<String> wares) {
        this.wares = wares;
    }

    public Map<String, Feature> getFeatures() {
        return features;
    }

    public void setFeatures(Map<String, Feature> features) {
        this.features = features;
    }

    //Class for the Features
    public static class Feature {
        private String name;
        private String type;
        private List<Integer> price;
        private Integer heal;
        private Integer sell;
        private Integer attack;
        private Integer defense;
        private String extras;

        public Feature() {
        }

        public Feature(String name, String type, List<Integer> price, Integer heal, Integer sell, Integer attack, Integer defense, String extras) {
            super();
            this.name = name;
            this.type = type;
            this.price = price;
            this.heal = heal;
            this.sell = sell;
            this.attack = attack;
            this.defense = defense;
            this.extras = extras;
        }

        //Getter and Setter (Feature)
        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getType() {
            return type;
        }

        public void setType(String type) {
            this.type = type;
        }

        public List<Integer> getPrice() {
            return price;
        }

        public void setPrice(List<Integer> price) {
            this.price = price;
        }

        public Integer getHeal() {
            return heal;
        }

        public void setHeal(Integer heal) {
            this.heal = heal;
        }

        public Integer getSell() {
            return sell;
        }

        public void setSell(Integer sell) {
            this.sell = sell;
        }

        public Integer getAttack() {
            return attack;
        }

        public void setAttack(Integer attack) {
            this.attack = attack;
        }

        public Integer getDefense() {
            return defense;
        }

        public void setDefense(Integer defense) {
            this.defense = defense;
        }

        public String getExtras() {
            return extras;
        }

        public void setExtras(String extras) {
            this.extras = extras;
        }
    }
}
