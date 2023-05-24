package com.example.undertale.mainchar;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class MainCharService {
    @Autowired
    private MainCharRepo mainCharRepo;

    public List<MainChar> getAllMainChars() {
        System.out.println(this.mainCharRepo.findAll());
        return (List<MainChar>) this.mainCharRepo.findAll();
    }

    public List<MainChar> getMainChar(String name) { return this.mainCharRepo.findByName(name); }

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

