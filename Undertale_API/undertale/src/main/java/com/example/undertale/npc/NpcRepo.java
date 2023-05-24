package com.example.undertale.npc;

import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

import java.util.List;

@RepositoryRestResource(collectionResourceRel = "npc", path = "char/npc")
public interface NpcRepo extends MongoRepository<Npc, String> {
    List<Npc> findByName(@Param("name") String name);
}