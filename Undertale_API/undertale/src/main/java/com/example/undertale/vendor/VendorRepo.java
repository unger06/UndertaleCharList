package com.example.undertale.vendor;

import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

import java.util.List;

@RepositoryRestResource(collectionResourceRel = "vendors", path = "char/vendor")
public interface VendorRepo extends MongoRepository<Vendor, String> {
    List<Vendor> findByName(@Param("name") String name);
}