# Blog Web Api Projesi

<p>
  Proje blog altyapısı için makale ve makaleye ait yorumları içeren kullanıcı ve kullanıcı role bilgilerini barındıran web api servis    uygulamasıdır. .Net Core ile geliştirilmiştir. Veritabanı olarak MSSQL tercih edilmiştir. ORM olarak Entityframework kullanılmıştır. 
 </p>
 <p>
    Loglama olarak işlemler, sistem hataları ve bilgilendirme logları Blog projesi içerisinde log.txt dosyası içerisine yazılmaktadır. Belki daha sonraki versiyonlarda veritabanına da yazılabilir. 
  </p>
  <p>
  Migration ile mevcut seed datalarla beraber veritabanını oluşturabilmek için Package Manager Console 'da Bll projesi seçiliyken aşağıdaki scripti yazmak yeterli olacaktır. User ve UserRole tablolalarına örnek datalar eklenecektir.
    <p>
      <code>update-database</code>
    </p>
 </p>

<p>
Authentication yapısı JWT ile oluşturulmuştur. Makale ve yorumlara ait bilgiler authentication dan sonra erişilebilecek şekilde tasarlanmıştır. Ancak authentication sonrasında oluşan token ile yapılan servis istekleri karşılanmaktadır. Authentication için aşağıdaki linke emailAddress ve password bilgilerini içeren post isteği gönderilmelidir. Başarılı olursa token üretilir. 
</p>
<p><b>http://localhost:49978/api/authentication/login</b></p>
<p>
  Projede tasarım deseni olarak kod tekrarının önüne geçmek için <b>Repository pattern</b> kullanılmıştır.
</p>
<p>
  Kullandığım teknolojileri birçok projede kullandım. Genelde Frontend tarafında SPA(genellikle Angular) kullandığım projelerde temel anlamda API tarafında bu yapıyı kullanmaktayım.    
</p>
<p>
  Projenin daha sonraki versiyonlarında galeri sayfası için binary olarak resim dosyası eklemesi yapılabilir. Sistemde kullanıcıların iletişim mesajları için geliştirmeler yapılabilir. Sistem bilgilerinin(email, url, sosyal medya hesapları vb) yer alacağı altyapı sağlanıp gerekli durumlarda mail gönderilebilir. SPA bir uygulamayla ilgili API projesi kullanılarak backend tarafına frontend de eklenebilir.   
</p>
