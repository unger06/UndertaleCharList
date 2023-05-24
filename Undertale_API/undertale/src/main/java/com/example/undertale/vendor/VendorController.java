package com.example.undertale.vendor;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@CrossOrigin(origins = "http://127.0.0.1:5500")
@RestController
@RequestMapping("/char/vendor")
public class VendorController {
    @RequestMapping("/home")
    public String serviceTest() { return "Das Service funktioniert!"; }

    @Autowired
    private VendorService vendorService;

    //@RequestMapping("/char/mainChar")
    @GetMapping("")
    public List<Vendor> getAllVendors() { return vendorService.getAllVendors(); }

    //@RequestMapping("/char/mainChar/{id}")
    @GetMapping("/{id}")
    public Optional<Vendor> getVendor(@PathVariable String id) { return vendorService.getVendor(id); }

    //@RequestMapping(method= RequestMethod.POST, value="/char/mainChar")
    @PostMapping("")
    public String addVendor(@RequestBody Vendor vendor) {
        vendorService.addVendor(vendor);
        String response = "{\"success\": true, \"message\": Vendor has been added successfully.}";
        return response;
    }

    //@RequestMapping(method=RequestMethod.PUT, value="/char/mainChar/{id}")
    @PutMapping("/{id}")
    public String updateVendor(@RequestBody Vendor vendor, @PathVariable String id) {
        vendorService.updateVendor(id, vendor);
        String response = "{\"success\": true, \"message\": Vendor has been updated successfully.}";
        return response;
    }


    //@RequestMapping(method=RequestMethod.DELETE, value="/foods/{id}")
    @DeleteMapping("/{id}")
    public String deleteVendor(@PathVariable String id) {
        vendorService.deleteVendor(id);
        String response = "{\"success\": true, \"message\": Vendor has been deleted successfully.}";
        return response;
    }
}
