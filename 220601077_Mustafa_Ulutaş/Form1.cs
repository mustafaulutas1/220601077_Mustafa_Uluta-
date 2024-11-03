using Npgsql;
using System.Collections.Generic;

namespace _220601077_Mustafa_Ulutaş
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //SELECT "Isim" FROM "IMDBSistemi"."Turler";
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=postgres; user ID=postgres; password=1234");
            baglanti.Open();
            comboBox1.Items.Clear();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT \"Isim\" FROM \"IMDBSistemi\".\"Turler\"", baglanti);
            NpgsqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0].ToString());
            }
            baglanti.Close();
            baglanti.Open();
            //SELECT "IMDBSistemi"."Kisiler"."ID", "Isim", "SahneIsim", "DogumTarihi", "Cinsiyet", "IMDBSistemi"."FilminKisisi"."KisiTuru" FROM "IMDBSistemi"."Kisiler" LEFT JOIN "IMDBSistemi"."FilminKisisi" ON "IMDBSistemi"."FilminKisisi"."KisiID" = "IMDBSistemi"."Kisiler"."ID"
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            NpgsqlCommand komut2 = new NpgsqlCommand("SELECT \"IMDBSistemi\".\"Kisiler\".\"ID\", \"Isim\", \"SahneIsim\", \"DogumTarihi\", \"Cinsiyet\", \"KisiTuru\" FROM \"IMDBSistemi\".\"Kisiler\" LEFT JOIN \"IMDBSistemi\".\"FilminKisisi\" ON \"IMDBSistemi\".\"FilminKisisi\".\"KisiID\" = \"IMDBSistemi\".\"Kisiler\".\"ID\"", baglanti);
            NpgsqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                if (oku2[5].ToString() == "Yönetmen")
                {
                    comboBox2.Items.Add(oku2[1].ToString());
                }
                else
                {
                    comboBox3.Items.Add(oku2[1].ToString());
                }
            }
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SELECT "Isim" FROM "IMDBSistemi"."Turler";
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=postgres; user ID=postgres; password=1234");
            baglanti.Open();
            comboBox1.Items.Clear();
            comboBox6.Items.Clear();
            NpgsqlCommand komut0 = new NpgsqlCommand("SELECT \"Isim\" FROM \"IMDBSistemi\".\"Turler\"", baglanti);
            NpgsqlDataReader oku0 = komut0.ExecuteReader();
            while (oku0.Read())
            {
                comboBox1.Items.Add(oku0[0].ToString());
                comboBox6.Items.Add(oku0[0].ToString());
            }
            baglanti.Close();
            baglanti.Open();
            //SELECT "IMDBSistemi"."Kisiler"."ID", "Isim", "SahneIsim", "DogumTarihi", "Cinsiyet", "IMDBSistemi"."FilminKisisi"."KisiTuru" FROM "IMDBSistemi"."Kisiler" LEFT JOIN "IMDBSistemi"."FilminKisisi" ON "IMDBSistemi"."FilminKisisi"."KisiID" = "IMDBSistemi"."Kisiler"."ID"
            comboBox2.Items.Clear();
            comboBox5.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            NpgsqlCommand komut2 = new NpgsqlCommand("SELECT \"IMDBSistemi\".\"Kisiler\".\"ID\", \"Isim\", \"SahneIsim\", \"DogumTarihi\", \"Cinsiyet\", \"KisiTuru\" FROM \"IMDBSistemi\".\"Kisiler\" LEFT JOIN \"IMDBSistemi\".\"FilminKisisi\" ON \"IMDBSistemi\".\"FilminKisisi\".\"KisiID\" = \"IMDBSistemi\".\"Kisiler\".\"ID\"", baglanti);
            NpgsqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                if (oku2[5].ToString() == "Yönetmen")
                {
                    comboBox2.Items.Add(oku2[1].ToString());
                    comboBox5.Items.Add(oku2[1].ToString());
                }
                else
                {
                    comboBox3.Items.Add(oku2[1].ToString());
                    comboBox4.Items.Add(oku2[1].ToString());
                }
            }
            baglanti.Close();

            //SELECT "ID", "Isim", "Cikis" FROM "IMDBSistemi"."Filmler";

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT \"ID\", \"Isim\", \"Cikis\" FROM \"IMDBSistemi\".\"Filmler\" ORDER BY \"ID\"", baglanti);
            NpgsqlDataReader oku = komut.ExecuteReader();
            listBox1.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            while (oku.Read())
            {
                listBox1.Items.Add(oku[1].ToString() + " " + oku[2].ToString());
                comboBox7.Items.Add(oku[1].ToString() + " " + oku[2].ToString());
                comboBox8.Items.Add(oku[1].ToString() + " " + oku[2].ToString());
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir film seçiniz.");
                return;
            }
            //SELECT "ID", "Isim", "TurID", "Reyting", "Butce", "Cikis", "Gisesi", "Afis" FROM "IMDBSistemi"."Filmler";
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=postgres; user ID=postgres; password=1234");
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT \"IMDBSistemi\".\"Filmler\".\"ID\", \"IMDBSistemi\".\"Filmler\".\"Isim\", \"IMDBSistemi\".\"Turler\".\"Isim\", \"Reyting\", \"Butce\", \"Cikis\", \"Gisesi\", \"Afis\" FROM \"IMDBSistemi\".\"Filmler\" LEFT JOIN \"IMDBSistemi\".\"Turler\" ON \"IMDBSistemi\".\"Filmler\".\"TurID\" = \"IMDBSistemi\".\"Turler\".\"ID\" WHERE \"IMDBSistemi\".\"Filmler\".\"ID\" = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", listBox1.SelectedIndex + 1);
            NpgsqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                label1.Text = "Ad: " + oku[1].ToString();
                label2.Text = "Tür: " + oku[2].ToString();
                label3.Text = "Reyting: " + oku[3].ToString();
                label4.Text = "Bütçe: " + oku[4].ToString();
                label5.Text = "Çıkış: " + oku[5].ToString();
                label6.Text = "Gişe: " + oku[6].ToString();
                pictureBox1.ImageLocation = "Afisler/" + oku[7].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            //SELECT "IMDBSistemi"."Kisiler"."ID", "Isim", "SahneIsim", "DogumTarihi", "Cinsiyet", "KisiTuru" FROM "IMDBSistemi"."Kisiler" LEFT JOIN "IMDBSistemi"."FilminKisisi" ON "IMDBSistemi"."Kisiler"."ID" = "IMDBSistemi"."FilminKisisi"."KisiID" WHERE "IMDBSistemi"."FilminKisisi"."FilmID" = 2
            NpgsqlCommand komut2 = new NpgsqlCommand("SELECT \"IMDBSistemi\".\"Kisiler\".\"ID\", \"Isim\", \"SahneIsim\", \"DogumTarihi\", \"Cinsiyet\", \"KisiTuru\" FROM \"IMDBSistemi\".\"Kisiler\" LEFT JOIN \"IMDBSistemi\".\"FilminKisisi\" ON \"IMDBSistemi\".\"Kisiler\".\"ID\" = \"IMDBSistemi\".\"FilminKisisi\".\"KisiID\" WHERE \"IMDBSistemi\".\"FilminKisisi\".\"FilmID\" = @p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", listBox1.SelectedIndex + 1);
            NpgsqlDataReader oku2 = komut2.ExecuteReader();
            listBox2.Items.Clear();
            listBox2.Items.Add("Yönetmenler");
            listBox3.Items.Clear();
            listBox3.Items.Add("Oyuncular");
            while (oku2.Read())
            {
                if (oku2[5].ToString() == "Yönetmen")
                {
                    listBox2.Items.Add(oku2[1].ToString());
                }
                else
                {
                    listBox3.Items.Add(oku2[1].ToString());
                }
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (
                textBox2.Text == "" ||
                comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1 ||
                comboBox3.SelectedIndex == -1 ||
                textBox6.Text == "" ||
                textBox7.Text == "" ||
                textBox8.Text == "" ||
                textBox9.Text == "" ||
                textBox10.Text == ""
                )
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=postgres; user ID=postgres; password=1234");
            baglanti.Open();
            int turid = 0;
            NpgsqlCommand komut = new NpgsqlCommand("SELECT \"ID\", \"Isim\" FROM \"IMDBSistemi\".\"Turler\" WHERE \"Isim\" = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            NpgsqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                turid = Convert.ToInt32(oku[0].ToString());
            }
            baglanti.Close();
            baglanti.Open();
            //INSERT INTO "IMDBSistemi"."Filmler"("ID", "Isim", "TurID", "Reyting", "Butce", "Cikis", "Gisesi", "Afis")

            NpgsqlCommand komut4 = new NpgsqlCommand("INSERT INTO \"IMDBSistemi\".\"Filmler\" (\"Isim\", \"TurID\", \"Reyting\", \"Butce\", \"Cikis\", \"Gisesi\", \"Afis\") VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", baglanti);
            komut4.Parameters.AddWithValue("@p2", textBox2.Text);
            komut4.Parameters.AddWithValue("@p3", turid);
            komut4.Parameters.AddWithValue("@p4", Convert.ToInt32(textBox6.Text));
            komut4.Parameters.AddWithValue("@p5", Convert.ToInt32(textBox7.Text));
            komut4.Parameters.AddWithValue("@p6", Convert.ToInt32(textBox8.Text));
            komut4.Parameters.AddWithValue("@p7", Convert.ToInt32(textBox9.Text));
            komut4.Parameters.AddWithValue("@p8", textBox10.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //UPDATE "IMDBSistemi"."Filmler"
            //SET "ID" =?, "Isim" =?, "TurID" =?, "Reyting" =?, "Butce" =?, "Cikis" =?, "Gisesi" =?, "Afis" =?

            if (
                               textBox1.Text == "" ||
                                              textBox2.Text == "" ||
                                                             comboBox1.SelectedIndex == -1 ||
                                                                            comboBox2.SelectedIndex == -1 ||
                                                                                           comboBox3.SelectedIndex == -1 ||
                                                                                                          textBox6.Text == "" ||
                                                                                                                         textBox7.Text == "" ||
                                                                                                                                        textBox8.Text == "" ||
                                                                                                                                                       textBox9.Text == "" ||
                                                                                                                                                                      textBox10.Text == ""
                                                                                                                                                                                     )
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=postgres; user ID=postgres; password=1234");
            baglanti.Open();
            int turid = comboBox6.SelectedIndex + 1;
            NpgsqlCommand komut = new NpgsqlCommand("UPDATE \"IMDBSistemi\".\"Filmler\" SET \"Isim\" = @p1, \"TurID\" = @p2, \"Reyting\" = @p3, \"Butce\" = @p4, \"Cikis\" = @p5, \"Gisesi\" = @p6, \"Afis\" = @p7 WHERE \"ID\" = @p8", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox12.Text);
            komut.Parameters.AddWithValue("@p2", turid);
            komut.Parameters.AddWithValue("@p3", Convert.ToInt32(textBox11.Text));
            komut.Parameters.AddWithValue("@p4", Convert.ToInt32(textBox5.Text));
            komut.Parameters.AddWithValue("@p5", Convert.ToInt32(textBox4.Text));
            komut.Parameters.AddWithValue("@p6", Convert.ToInt32(textBox3.Text));
            komut.Parameters.AddWithValue("@p7", textBox1.Text);
            komut.Parameters.AddWithValue("@p8", comboBox7.SelectedIndex + 1);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("UPDATE \"IMDBSistemi\".\"FilminKisisi\" SET \"KisiID\" = @p1, \"KisiTuru\" = @p2 WHERE \"FilmID\" = @p3", baglanti);
            komut2.Parameters.AddWithValue("@p1", comboBox5.SelectedIndex + 1);
            komut2.Parameters.AddWithValue("@p2", "Yönetmen");
            komut2.Parameters.AddWithValue("@p3", comboBox7.SelectedIndex + 1);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("UPDATE \"IMDBSistemi\".\"FilminKisisi\" SET \"KisiID\" = @p1, \"KisiTuru\" = @p2 WHERE \"FilmID\" = @p3", baglanti);
            komut3.Parameters.AddWithValue("@p1", comboBox4.SelectedIndex + 1);
            komut3.Parameters.AddWithValue("@p2", "Oyuncu");
            komut3.Parameters.AddWithValue("@p3", comboBox7.SelectedIndex + 1);
            komut3.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir film seçiniz.");
                return;
            }
            if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=postgres; user ID=postgres; password=1234");
                baglanti.Open();
                NpgsqlCommand komut2 = new NpgsqlCommand("DELETE FROM \"IMDBSistemi\".\"FilminKisisi\" WHERE \"FilmID\" = @p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", listBox1.SelectedIndex + 1);
                komut2.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("DELETE FROM \"IMDBSistemi\".\"Filmler\" WHERE \"ID\" = @p1", baglanti);
                komut.Parameters.AddWithValue("@p1", listBox1.SelectedIndex + 1);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }

        }
    }
}
