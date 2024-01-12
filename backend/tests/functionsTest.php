<?php

require_once 'inc/db.inc';

use PHPUnit\Framework\TestCase;
use PHPUnit\Framework\AssertionFailedError;
use PHPUnit\Framework\AssertException;
use PHPUnit\Framework\MockObject\MockObject;

/**
 * Jó profil példa
 * id: 1
 * nev: asd
 * email: asd@gmail.com
 * jelszo: 1234
 */

class FunctionsTest extends TestCase
{
    private $kapcsolat;

    protected function setUp(): void
    {
        $this->kapcsolat = csatlakozas();
    }

    protected function tearDown(): void
    {
        mysqli_close($this->kapcsolat);
    }

    public function testCsatlakozas(): void
    {
        $this->assertInstanceOf(mysqli::class, $this->kapcsolat);
    }

    public function testCsatlakozasSikeres(): void
    {
        $this->assertInstanceOf(mysqli::class, $this->kapcsolat);
        $this->assertTrue($this->kapcsolat->ping(), 'Sikeres kapcsolódás');
    }

    public function testCsatlakozasHibasAdatokkal(): void
    {
        define('DB_USER', 'direktrossz');
        define('DB_PASS', 'direktrossz');
        define('DB_DBASE', 'direktrossz');

        $this->expectException(AssertionFailedError::class);

        try {
            csatlakozas();
        } catch (mysqli_sql_exception $e) {
            throw new AssertException('Az elvárt kivétel nem történt meg.', 0, $e);
        } catch (Exception $e) {
            throw new AssertException('Érvénytelen típusú kivétel.', 0, $e);
        }
    }

    public function testCsatlakozasKapcsolatZarva(): void
    {
        $this->assertInstanceOf(mysqli::class, $this->kapcsolat);
        mysqli_close($this->kapcsolat);

        $this->expectException(AssertionFailedError::class);

        try {
            mysqli_query($this->kapcsolat, 'SELECT 1');
        } catch (mysqli_sql_exception $e) {
            throw new AssertException('Az elvárt kivétel nem történt meg.', 0, $e);
        } catch (Exception $e) {
            throw new AssertException('Érvénytelen típusú kivétel.', 0, $e);
        }
    }

    public function testLekerdezes(): void
    {
        $result = lekerdezes($this->kapcsolat);
        $this->assertInstanceOf(mysqli_result::class, $result);
    }

    public function testLekerdezesEredmenyNemUres(): void
    {
        $result = lekerdezes($this->kapcsolat);
        $this->assertInstanceOf(mysqli_result::class, $result);
        $this->assertGreaterThan(0, mysqli_num_rows($result), 'Lekérdezés eredménye nem üres');
    }

    public function testFeltolt(): void
    {
        $user = [
            "nev" => "asd1234",
            "email" => "asd1234@gmail.com",
            "jelszo" => "1234"
        ];

        $result = feltolt($this->kapcsolat, $user);
        $this->assertTrue($result);
    }

    public function testFeltoltIsmeteltBeszuras(): void
    {
        $user = [
            "nev" => "asd1234",
            "email" => "asd1234@gmail.com",
            "jelszo" => "1234"
        ];

        $result1 = feltolt($this->kapcsolat, $user);
        $result2 = feltolt($this->kapcsolat, $user);

        $this->assertTrue($result1);
        $this->assertFalse($result2, 'Második beszúrásra false');
    }
    public function testEgyLeker(): void
    {
        $usernev = 'direktrossz';
        $jelszo = hash('sha256', 'direktrossz');
        $result = egy_leker($this->kapcsolat, $usernev, $jelszo);
        $this->assertTrue($result);
    }

    public function testEgyLekerSikertelenLekeres(): void
    {
        $usernev = 'direktrossz';
        $jelszo = hash('sha256', 'direktrossz');
        $result = egy_leker($this->kapcsolat, $usernev, $jelszo);
        $this->assertFalse($result);
    }

    public function testUserLeker(): void
    {
        $usernev = 'asd';
        $result = user_leker($this->kapcsolat, $usernev);
        $this->assertInstanceOf(mysqli_result::class, $result);
    }

    public function testUserLekerHibasFelhasznalonev(): void
    {
        $usernev = 'direktrossz';
        $this->expectException(mysqli_sql_exception::class);
        user_leker($this->kapcsolat, $usernev);
    }

    public function testProfilLeker(): void
    {
        $id = 1;
        $result = profil_leker($this->kapcsolat, $id);

        if (mysqli_num_rows($result) > 0) {
            $this->assertInstanceOf(mysqli_result::class, $result);
        } else {
            $this->assertEquals(0, $result);
        }
    }

    public function testProfilLekerHibasAzonosito(): void
    {
        $id = -1;
        $this->expectException(mysqli_sql_exception::class);
        profil_leker($this->kapcsolat, $id);
    }

    public function testProfilLekerNemLetezoFelhasznalo(): void
    {
        $id = 99999999;
        $result = profil_leker($this->kapcsolat, $id);
        $this->assertEquals(0, $result);
    }

    public function testJelszoModosit(): void
    {
        $usernev = 'asd';
        $regi_jelszo = '1234';
        $uj_jelszo = '12345';

        $result = jelszo_modosit($this->kapcsolat, $usernev, $uj_jelszo, $regi_jelszo);
        $this->assertTrue($result);
    }

    public function testJelszoModositHibasRegiJelszo(): void
    {
        $usernev = 'asd';
        $regi_jelszo = 'direktrossz';
        $uj_jelszo = '12345';

        $result = jelszo_modosit($this->kapcsolat, $usernev, $uj_jelszo, $regi_jelszo);
        $this->assertFalse($result);
    }

    public function testJelszoModositUresRegiJelszo(): void
    {
        $usernev = 'asd';
        $regi_jelszo = '';
        $uj_jelszo = '12345';

        $result = jelszo_modosit($this->kapcsolat, $usernev, $uj_jelszo, $regi_jelszo);
        $this->assertFalse($result);
    }

    public function testJelszoModositHibasFelhasznalonev(): void
    {
        $usernev = 'direktrossz';
        $regi_jelszo = '1234';
        $uj_jelszo = '12345';

        $result = jelszo_modosit($this->kapcsolat, $usernev, $uj_jelszo, $regi_jelszo);
        $this->assertFalse($result);
    }

    public function testJelszoEllenorzes(): void
    {
        $usernev = 'asd';
        $jelszo_hash = hash('sha256', '1234');

        $result = jelszo_ellenorzes($this->kapcsolat, $usernev, $jelszo_hash);
        $this->assertTrue($result);
    }

    public function testJelszoEllenorzesHibasJelszo(): void
    {
        $usernev = 'asd';
        $jelszo_hash = hash('sha256', 'direktrossz');

        $result = jelszo_ellenorzes($this->kapcsolat, $usernev, $jelszo_hash);
        $this->assertFalse($result);
    }

    public function testJelszoEllenorzesUresJelszoHash(): void
    {
        $usernev = 'asd';
        $jelszo_hash = '';

        $result = jelszo_ellenorzes($this->kapcsolat, $usernev, $jelszo_hash);
        $this->assertFalse($result);
    }

    public function testJelszoEllenorzesHibasFelhasznalonev(): void
    {
        $usernev = 'direktrossz';
        $jelszo_hash = hash('sha256', '1234');

        $result = jelszo_ellenorzes($this->kapcsolat, $usernev, $jelszo_hash);
        $this->assertFalse($result);
    }

    public function testEredmenyekLekerdezeseSikeres(): void
    {
        $usernev = 'asd';

        $result = eredmenyek_lekerdezese($this->kapcsolat, $usernev);

        $this->assertInstanceOf(MockObject::class, $result, 'Az eredmények típusa mysqli_result kell, hogy legyen');
        $this->assertNotFalse($result, 'Az eredmények lekérdezése nem lehet sikertelen');
    }

    public function testEredmenyekLekerdezeseSikertelen(): void
    {
        $usernev = 'direktrossz';

        $result = eredmenyek_lekerdezese($this->kapcsolat, $usernev);

        $this->assertInstanceOf(MockObject::class, $result, 'Az eredmények típusa mysqli_result kell, hogy legyen');
        $this->assertFalse($result, 'Az eredmények lekérdezésének sikertelennek kell lennie');
    }
}
//  vendor/bin/phpunit tests/functionsTest.php