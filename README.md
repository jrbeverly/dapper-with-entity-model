# EntityModel Dapper Experiment Case

Exported case of experimenting with using Postgres Functions, Dapper & Entity.Model.

## Notes

Experimenting a bit more with the entity model of splitting out the "database" components (e.g. `ID`) from the model objects, with an aim towards designing a strict interface for working with the database, that could be generated from a baseline specification. This would allow for things like ReadOnly entities, better field filtering & potential for "programmatic" improvements to how the database handles searches.

Continuing with the direction of leveraging functions/stored procedures for databases. This simplifies the internals of the API, letting the clients be only consumers, and having external sources be responsible for the provisioning of the database schema.

Potential areas of interest:

- Constructing a "Database" type schema bundle, that can be provisioned on-demand by services (allows DB provisioning to be external "infrastructure")
- "Models" can generated the DB & interface components for services, as well as CLIs for easy interaction
- Schema bundles can be combined for "migration" updates & verification policies (tests / 'DB Policy' - similar to a "IAM Policy") 
- Common classes for interacting with the database, with tools to construct the `CommandDefinitions` to send messages to database
- How to handle the idea of "chaining", e.g. `X` => Data, then use that data to get `Y`.


Options for tools that work well in devcontainers for performing postman-like queries against a server for rapid development.
