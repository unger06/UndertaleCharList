package com.example.undertale;
import com.mongodb.client.MongoClients;
import com.mongodb.client.MongoDatabase;
import org.springframework.boot.actuate.health.Health;
import org.springframework.boot.actuate.health.HealthIndicator;
import org.springframework.stereotype.Component;

@Component
public class DatabaseHealthIndicator implements HealthIndicator {
    @Override
    public Health health() {
        boolean databaseConnected = checkDatabaseConnection(); // Custom method to check the database connection

        if (databaseConnected) {
            return Health.up().withDetail("database", "Connected").build();
        } else {
            return Health.down().withDetail("database", "Not Connected").build();
        }
    }

    private boolean checkDatabaseConnection() {
        try {
            String connectionString = "mongodb+srv://user:1nT7ztgk1nOXPGD2@characters.mftjfb9.mongodb.net/undertale?retryWrites=true&w=majority";
            String databaseName = "undertale";

            try (var mongoClient = MongoClients.create(connectionString)) {
                MongoDatabase database = mongoClient.getDatabase(databaseName);

                database.listCollectionNames().first();
            }
            return true;
        } catch (Exception e) {
            return false;
        }
    }
}
