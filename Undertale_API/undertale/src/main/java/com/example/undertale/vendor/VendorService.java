package com.example.undertale.vendor;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class VendorService {
    @Autowired
    private VendorRepo vendorRepo;

    public List<Vendor> getAllVendors() {
        System.out.println(this.vendorRepo.findAll());
        return (List<Vendor>) this.vendorRepo.findAll();
    }

    public Optional<Vendor> getVendor(String id) {
        return this.vendorRepo.findById(id);
    }

    public void addVendor(Vendor vendor) {
        this.vendorRepo.save(vendor);
    }

    public void updateVendor(String id, Vendor vendor) {
        this.vendorRepo.save(vendor);
    }

    public void deleteVendor(String id) {
        this.vendorRepo.deleteById(id);
    }
}
