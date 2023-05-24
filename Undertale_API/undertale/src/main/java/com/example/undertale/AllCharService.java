package com.example.undertale;

import com.example.undertale.mainchar.MainCharRepo;
import com.example.undertale.npc.NpcRepo;
import com.example.undertale.vendor.VendorRepo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class AllCharService {
    @Autowired
    private MainCharRepo mainCharRepo;

    @Autowired
    private VendorRepo vendorRepo;

    @Autowired
    private NpcRepo npcRepo;

    public List<Object> getAllChars() {
        List<Object> chars = new ArrayList<>();
        chars.addAll(mainCharRepo.findAll());
        chars.addAll(vendorRepo.findAll());
        chars.addAll(npcRepo.findAll());
        return chars;
    }
}
