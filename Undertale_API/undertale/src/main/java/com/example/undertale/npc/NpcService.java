package com.example.undertale.npc;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class NpcService {
    @Autowired
    private NpcRepo npcRepo;

    public List<Npc> getAllNpcs() {
        System.out.println(this.npcRepo.findAll());
        return (List<Npc>) this.npcRepo.findAll();
    }

    public Optional<Npc> getNpc(String id) {
        return this.npcRepo.findById(id);
    }

    public void addNpc(Npc npc) {
        this.npcRepo.save(npc);
    }

    public void updateNpc(String id, Npc npc) {
        this.npcRepo.save(npc);
    }

    public void deleteNpc(String id) {
        this.npcRepo.deleteById(id);
    }
}
