public void UploadFile()
{
	//upload file extension name
	HttpPostedFile fileUpload = this.FileUpload1.PostedFile;
	string fileExtension = fileUpload.FileName.Substring(fileUpload.FileName.LastIndexOf(',')).Trim();
	var result = FileType.Where(p=>p.ToLower().Equals(fileExtension.Tolower()));
	if(result == null || result.Count() == 0)
	{
		divErr.InnerHtml = "Error:your upload file type error(not support"+fileExtension+"file type)";
		return;
	}
	//jurge file size
	if(fileUpload.ContentLength > FileMaxSize * 1024)
	{
		divErr.InnerHtml = "Error:your upload file("+fileUpload.FileName+")beyond max size"+FileMaxSize+"KB";
		return;
	}
	//
	string Name = fileUpload.FileName.Substring(fileUpload.FileName.LastIndexOf("\\") + 1);
	string fs = fileUpload.InputStream;
	BinaryReader br = new BinaryReader(fs);
	int filesize = (int)fs.Length;
	byte[] bytes = br.ReadBytes(filesize);
	br.Close();
	fs.Close();
}
