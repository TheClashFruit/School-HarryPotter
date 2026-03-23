using HarryPotter.Serializables;
using MySql.Data.MySqlClient;

namespace HarryPotter.Util;

public class Database : IDisposable {
    private static readonly MySqlConnection Connection =
        new("server=localhost;uid=schl;password=secure123;database=schl_harrypotter");

    public Database() {
        Connection.Open();
    }

    public void Dispose() {
        Connection.Dispose();
    }

    public void CreateTables() {
        var cmd = new MySqlCommand(@"
            CREATE TABLE IF NOT EXISTS `spells` (
                `id` INT PRIMARY KEY AUTO_INCREMENT,
                `name` TEXT NOT NULL,
                `use` TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS `characters` (
                `id` INT PRIMARY KEY AUTO_INCREMENT,
                `full_name` TEXT NOT NULL,
                `nickname` TEXT NOT NULL,
                `hogwarts_house` TEXT NOT NULL,
                `interpreted_by` TEXT NOT NULL,
                `image` TEXT NOT NULL,
                `birthdate` DATETIME NOT NULL
            );

            CREATE TABLE IF NOT EXISTS `children` (
                `id` INT PRIMARY KEY AUTO_INCREMENT,
                `character_id` INT NOT NULL,
                `name` TEXT NOT NULL,
                
                CONSTRAINT character_id_child_fk FOREIGN KEY (`character_id`) REFERENCES `characters`(`id`)
            );

            CREATE TABLE IF NOT EXISTS `character_spells` (
                `character_id` INT NOT NULL,
                `spell_id` INT NOT NULL,
                
                CONSTRAINT character_id_spell_fk FOREIGN KEY (`character_id`) REFERENCES `characters`(`id`),
                CONSTRAINT spell_id_spell_fk FOREIGN KEY (`spell_id`) REFERENCES `spells`(`id`),
                
                PRIMARY KEY(`character_id`, `spell_id`)
            );
        ", Connection);

        cmd.ExecuteNonQuery();
    }

    public void TruncateTables() {
        var cmd = new MySqlCommand(@"
            DELETE FROM `character_spells`;
            DELETE FROM `children`;
            DELETE FROM `characters`;
            DELETE FROM `spells`;

            ALTER TABLE `children` AUTO_INCREMENT = 1;
            ALTER TABLE `characters` AUTO_INCREMENT = 1;
            ALTER TABLE `spells` AUTO_INCREMENT = 1;
        ", Connection);

        cmd.ExecuteNonQuery();
    }

    public void InsertSpell(Spell spell) {
        var cmd = new MySqlCommand(@"
            INSERT INTO `spells` (`id`, `name`, `use`) VALUES (@id, @name, @use);
        ", Connection);

        cmd.Parameters.AddWithValue("@id", spell.Index);
        cmd.Parameters.AddWithValue("@name", spell.Name);
        cmd.Parameters.AddWithValue("@use", spell.Use);

        cmd.ExecuteNonQuery();
    }

    public void InsertCharacter(Character character) {
        var cmdC = new MySqlCommand(@"
            INSERT INTO `characters` (
                                      `id`,
                                      `full_name`,
                                      `nickname`,
                                      `hogwarts_house`,
                                      `interpreted_by`,
                                      `image`,
                                      `birthdate`
                                     ) VALUES (
                                               @id,
                                               @name,
                                               @nickname,
                                               @hogwarts_house,
                                               @interpreted_by,
                                               @image,
                                               @birthdate
                                              );
        ", Connection);

        cmdC.Parameters.AddWithValue("@id", character.Index);
        cmdC.Parameters.AddWithValue("@name", character.FullName);
        cmdC.Parameters.AddWithValue("@nickname", character.Nickname);
        cmdC.Parameters.AddWithValue("@hogwarts_house", character.HogwartsHouse);
        cmdC.Parameters.AddWithValue("@interpreted_by", character.InterpretedBy);
        cmdC.Parameters.AddWithValue("@image", character.Image);
        cmdC.Parameters.AddWithValue("@birthdate", character.BirthDate);

        cmdC.ExecuteNonQuery();

        character.Children.ForEach(child => {
            var cmd = new MySqlCommand(@"
                INSERT INTO `children` (`name`, `character_id`) VALUES (@name, @cid);
            ", Connection);

            cmd.Parameters.AddWithValue("@name", child);
            cmd.Parameters.AddWithValue("@cid", character.Index);

            cmd.ExecuteNonQuery();
        });

        character.KnownSpells.ForEach(spell => {
            var cmd = new MySqlCommand(@"
                INSERT INTO `character_spells` (`character_id`, `spell_id`) VALUES (@cid, @sid);
            ", Connection);

            cmd.Parameters.AddWithValue("@cid", character.Index);
            cmd.Parameters.AddWithValue("@sid", spell);

            cmd.ExecuteNonQuery();
        });
    }
}