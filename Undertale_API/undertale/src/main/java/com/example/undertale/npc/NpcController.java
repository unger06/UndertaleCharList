package com.example.undertale.npc;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@CrossOrigin(origins = "http://127.0.0.1:5500")
@RestController
@RequestMapping("/char/npc")
public class NpcController {
    @RequestMapping("/home")
    public String serviceTest() { return "Das Service funktioniert!"; }

    @Autowired
    private NpcService npcService;

    //@RequestMapping("/char/mainChar")
    @GetMapping("")
    public List<Npc> getAllNpcs() {
        return npcService.getAllNpcs();
    }

    //@RequestMapping("/char/mainChar/{id}")
    @GetMapping("/{id}")
    public Optional<Npc> getNpc(@PathVariable String id) { return npcService.getNpc(id); }

    //@RequestMapping(method= RequestMethod.POST, value="/char/mainChar")
    @PostMapping("")
    public String addNpc(@RequestBody Npc npc) {
        npcService.addNpc(npc);
        String response = "{\"success\": true, \"message\": NPC has been added successfully.}";
        return response;
    }

    //@RequestMapping(method=RequestMethod.PUT, value="/char/mainChar/{id}")
    @PutMapping("/{id}")
    public String updateNpc(@RequestBody Npc npc, @PathVariable String id) {
        npcService.updateNpc(id, npc);
        String response = "{\"success\": true, \"message\": NPC has been updated successfully.}";
        return response;
    }


    //@RequestMapping(method=RequestMethod.DELETE, value="/foods/{id}")
    @DeleteMapping("/{id}")
    public String deleteNpc(@PathVariable String id) {
        npcService.deleteNpc(id);
        String response = "{\"success\": true, \"message\": NPC has been deleted successfully.}";
        return response;
    }
}
