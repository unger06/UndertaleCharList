package com.example.undertale.mainchar;

import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

import java.util.List;
import java.util.Optional;

@RepositoryRestResource(collectionResourceRel = "mainCharacters", path = "char/mainChar")
public interface MainCharRepo extends MongoRepository<MainChar, String> {
    List<MainChar> findByName(@Param("name") String name);
}

