package com.example.undertale;

import com.example.undertale.mainchar.MainChar;
import com.example.undertale.mainchar.MainCharService;
import com.example.undertale.npc.Npc;
import com.example.undertale.npc.NpcController;
import com.example.undertale.npc.NpcService;
import com.example.undertale.vendor.VendorController;
import com.example.undertale.vendor.VendorService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/char")
public class AllCharController {
    @RequestMapping("/home")
    public String serviceTest() { return "Das Service funktioniert!"; }

    @Autowired
    private AllCharService allCharService;

    @GetMapping("")
    public List<Object> getAllChars() {
        return allCharService.getAllChars();
    }
}
