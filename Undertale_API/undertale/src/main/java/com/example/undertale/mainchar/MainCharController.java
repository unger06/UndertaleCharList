package com.example.undertale.mainchar;

import org.bson.types.ObjectId;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@CrossOrigin(origins = "http://127.0.0.1:5500")
@RestController
@RequestMapping("/char/mainChar")
public class MainCharController {
    @RequestMapping("/home")
    public String serviceTest() { return "Das Service funktioniert!"; }

    @Autowired
    private MainCharService mainCharService;

    //@RequestMapping("/char/mainChar")
    @GetMapping("")
    public List<MainChar> getAllMainChars() {
        return mainCharService.getAllMainChars();
    }

    //@RequestMapping("/char/mainChar/{id}")
    @GetMapping("/{name}")
    public List<MainChar> getMainChar(@PathVariable String name) { return mainCharService.getMainChar(name); }

    //@RequestMapping(method= RequestMethod.POST, value="/char/mainChar")
    @PostMapping("")
    public String addMainChar(@RequestBody MainChar mainChar) {
        mainCharService.addMainChar(mainChar);
        String response = "{\"success\": true, \"message\": Main Character has been added successfully.}";
        return response;
    }

    //@RequestMapping(method=RequestMethod.PUT, value="/char/mainChar/{id}")
    @PutMapping("/{id}")
    public String updateMainChar(@RequestBody MainChar mainChar, @PathVariable String id) {
        mainCharService.updateMainChar(id, mainChar);
        String response = "{\"success\": true, \"message\": Main Character has been updated successfully.}";
        return response;
    }


    //@RequestMapping(method=RequestMethod.DELETE, value="/foods/{id}")
    @DeleteMapping("/{id}")
    public String deleteMainChar(@PathVariable String id) {
        mainCharService.deleteMainChar(id);
        String response = "{\"success\": true, \"message\": Main Character has been deleted successfully.}";
        return response;
    }
}
